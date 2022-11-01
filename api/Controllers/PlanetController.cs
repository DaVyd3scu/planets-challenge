using api.Data;
using api.Models;
using api.Models.ActionModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api")]
    public class PlanetController : ApiAppController
    {
        private readonly PlanetsChallengeDbContext dbContext;

        public PlanetController(PlanetsChallengeDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("SolarSystems")]
        public async Task<IActionResult> GetAllSolarSystems()
        {
            var solarSystems = await dbContext.SolarSystems.ToListAsync();

            if (solarSystems == null)
            {
                return NoContent();
            }

            return Ok(solarSystems);
        }

        [HttpGet("SolarSystem/{id:int}")]
        public async Task<IActionResult> GetSolarSystem([FromRoute] int id)
        {
            var solarSystem = await dbContext.SolarSystems.FirstOrDefaultAsync(s => s.SolarSystemId == id);

            if (solarSystem == null)
            {
                return NotFound();
            }

            return Ok(solarSystem);
        }

        // Gets all planets from a solar system
        [HttpGet("Planets/{solarSystemId:int}")]
        public async Task<IActionResult> GetAllPlanets([FromRoute] int solarSystemId)
        {
            var planets = await dbContext.Planets
                .Where(p => p.SolarSystemId == solarSystemId)
                .Include(p => p.SolarSystem)
                .ToListAsync();

            if (planets == null)
            {
                return NoContent();
            }

            return Ok(planets);
        }

        // Gets a planet from a solar system
        [HttpGet("[controller]/{planetId:int}")]
        public async Task<IActionResult> GetPlanet([FromRoute] int planetId)
        {
            var planet = await dbContext.Planets
                .Where(p => p.PlanetId == planetId)
                .Include(p => p.SolarSystem)
                .FirstOrDefaultAsync();

            if (planet == null)
            {
                return NotFound();
            }

            return Ok(planet);
        }

        // Adds a solar system
        [HttpPost("SolarSystem")]
        public async Task<IActionResult> AddSolarSystem([FromBody] SolarSystem solarSystem)
        {
            await dbContext.SolarSystems.AddAsync(solarSystem);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        // Adds a planet in the specified solar system
        [HttpPost("[controller]")]
        public async Task<IActionResult> AddPlanet([FromBody] InsertPlanet planet)
        {
            if (planet.Status == "") // If the user doesn't specify a status for the planet
            {
                planet.Status = "TODO"; // TODO is default
            }
            // Adding the solar system data
            planet.SolarSystem = await dbContext.SolarSystems.FirstOrDefaultAsync(s => s.SolarSystemId == planet.SolarSystemId);

            await dbContext.Planets.AddAsync(planet);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("[controller]/{planetId:int}")]
        public async Task<IActionResult> UpdatePlanetStatus([FromRoute] int planetId, [FromBody] UpdatePlanet planet)
        {
            var findPlanet = await dbContext.Planets.Where(p => p.PlanetId == planetId).FirstOrDefaultAsync();
            if (findPlanet == null)
            {
                return NotFound("Planet was not found");
            }

            var user = await dbContext.Captains.Where(c => c.CaptainId == planet.CaptainId).FirstOrDefaultAsync();
            if (user == null)
            {
                return NotFound("User was not found.");
            }

            findPlanet.Description = planet.Description;
            findPlanet.Status = planet.Status;
            findPlanet.Captain = user;

            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
