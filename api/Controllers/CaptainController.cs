using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class CaptainController : ApiAppController
    {
        private readonly PlanetsChallengeDbContext dbContext;

        public CaptainController(PlanetsChallengeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("~/api/Captains")]
        public async Task<IActionResult> GetAllCaptains()
        {
            var captains = await dbContext.Captains.ToListAsync();

            if (captains == null)
            {
                return NoContent();
            }

            return Ok(captains);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCaptain([FromRoute] int id)
        {
            var captain = await dbContext.Captains.FirstOrDefaultAsync(c => c.CaptainId == id);

            if (captain == null)
            {
                return NotFound();
            }

            return Ok(captain);
        }

        // Gets all robots based on captain id
        [HttpGet("{id:int}/robots")]
        public async Task<IActionResult> GetRobots([FromRoute] int id)
        {
            var robots = await dbContext.Robots
                .Where(r => r.CaptainId == id)
                .Include(r => r.Captain)
                .ToListAsync();

            if (robots == null)
            {
                return NoContent();
            }

            return Ok(robots);
        }

        [HttpPost]
        public async Task<IActionResult> AddCaptain([FromBody] Captain captain)
        {
            await dbContext.AddAsync(captain);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
