using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MilesBoxApi.Models;

namespace MilesBoxApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly ModelContext _context;

        public AdminController(ModelContext context)
        {
            _context = context;
        }

        #region BOXES
        //   POST: api/Admin/5/boxes
        [HttpPost("{adminId}/boxes")]
        public async Task<ActionResult<Box>> PostBox(int adminId, Box box)
        {
            _context.Boxes.Add(box);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBox", new { id = box.BoxId }, box);
        }

        // DELETE: api/Admin/5/boxes
        [HttpDelete("{adminId}/boxes/{boxId}")]
        public async Task<ActionResult<Box>> DeleteBox(int adminId, int boxId)
        {
            var box = await _context.Boxes.FindAsync(boxId);
            if (box == null)
            {
                return NotFound();
            }

            _context.Boxes.Remove(box);
            await _context.SaveChangesAsync();

            return box;
        }
        #endregion

        #region SENSORS
        //    POST: api/Admin/5/sensors
        [HttpPost("{adminId}/sensors")]
        public async Task<ActionResult<Sensor>> PostSensor(int adminId, Sensor sensor)
        {
            _context.Sensors.Add(sensor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSensor", new { id = sensor.SensorId }, sensor);
        }

        // DELETE: api/Admin/5/sensors
        [HttpDelete("{adminId}/sensors/{sensorId}")]
        public async Task<ActionResult<Sensor>> DeleteSensor(int adminId, int sensorId)
        {
            var sensor = await _context.Sensors.FindAsync(sensorId);
            if (sensor == null)
            {
                return NotFound();
            }

            _context.Sensors.Remove(sensor);
            await _context.SaveChangesAsync();

            return sensor;
        }
        #endregion

        #region USERS
        //  POST: api/Admin/5/users
        [HttpPost("{adminId}/users")]
        public async Task<ActionResult<User>> PostUser(int adminId, User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Admin/5/users
        [HttpDelete("{adminId}/users/{userId}")]
        public async Task<ActionResult<User>> DeleteUser(int adminId, int userId)
        {
            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }
        #endregion
    }
}
