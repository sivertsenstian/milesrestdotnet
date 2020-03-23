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
    public class BoxesController : ControllerBase
    {
        private readonly ModelContext _context;

        public BoxesController(ModelContext context)
        {
            _context = context;
        }

        // GET: api/Boxes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoxDto>>> GetBoxes()
        {
            return await _context.Boxes.Select(box =>
            new BoxDto()
            {
                id = box.BoxId,
                user = box.User.Name,
                description = box.Description
            }).ToListAsync();
        }

        // GET: api/Boxes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BoxDto>> GetBox(int id)
        {
            var box = await _context.Boxes.FindAsync(id);

            if (box == null)
            {
                return NotFound();
            }

            return new BoxDto()
            {
                id = box.BoxId,
                user = box.User.Name,
                description = box.Description
            };
        }

        // GET: api/Boxes/5/sensors
        [HttpGet("{boxId}/Sensors")]
        public async Task<ActionResult<IEnumerable<Sensor>>> GetBoxSensors(int boxId)
        {
            return await _context.Sensors.ToListAsync();
        }

        // GET: api/Boxes/5/sensors/3
        [HttpGet("{boxId}/Sensors/${sensorId}")]
        public async Task<ActionResult<IEnumerable<Measurement>>> GetBoxSensorMeasurements(int boxId, int sensorId)
        {
            return await _context.Measurements.Where(x => x.BoxId == boxId && x.SensorId == sensorId).ToListAsync();
        }
    }
}
