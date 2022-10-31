using api.Data;
using api.Models;
using api.Models.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;

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

        // Encrypts the password
        private static string HashPassword(string? password)
        {
            var asByteArray = Encoding.Default.GetBytes(password);

            return Convert.ToBase64String(SHA256.Create().ComputeHash(asByteArray));
        }

        [HttpPost("~/api/Login")]
        public async Task<IActionResult> Login([FromBody] UserLogin user)
        {
            var hashedPassword = HashPassword(user.Password);
            var findUser = await dbContext.Captains
                .Where(u => u.Username == user.Username && u.Password == hashedPassword)
                .FirstOrDefaultAsync();

            if (findUser == null)
            {
                return BadRequest("Username or password is incorrect.");
            }

            return NoContent();
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
        public async Task<IActionResult> AddCaptain([FromBody] UserRegister user)
        {
            var checkUserExists = await dbContext.Captains.Where(u => u.Username == user.Username).FirstOrDefaultAsync();

            if (checkUserExists != null)
            {
                return BadRequest("User already exists!");
            }

            user.Password = HashPassword(user.Password);

            await dbContext.AddAsync(user);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}
