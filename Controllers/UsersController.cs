using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MilesBoxApi.Models;

namespace MilesBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ModelContext _context;

        public UsersController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            return await _context.Users.Select(user => new UserDto()
            {
                id = user.UserId,
                name = user.Name,
                boxes = user.Boxes.Select(box => new BoxDto()
                {
                    id = box.BoxId,
                    user = box.User.Name,
                    description = box.Description
                })
            }).ToListAsync();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return new UserDto()
            {
                id = user.UserId,
                name = user.Name,
                boxes = user.Boxes.Select(box => new BoxDto()
                {
                    id = box.BoxId,
                    user = box.User.Name,
                    description = box.Description
                })
            };
        }

        // GET: api/Users/5
        [HttpGet("{id}/boxes")]
        public async Task<ActionResult<IEnumerable<BoxDto>>> GetUserBoxes(int id)
        {
            return await _context.Boxes.Where(x => x.UserId == id).Select(box => new BoxDto()
            {
                id = box.BoxId,
                user = box.User.Name,
                description = box.Description
            }).ToListAsync();
        }

        // POST: api/Users/5/Boxes
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost("{id}/boxes")]
        public async Task<ActionResult<Box>> PostUserBox(int id, Box box)
        {
            box.UserId = id;
            _context.Boxes.Add(box);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserBoxes", new { id = box.UserId }, box);
        }

    }
}
