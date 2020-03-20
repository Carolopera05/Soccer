using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Soccer.Web.Data;
using Soccer.Web.Data.Entities;
using System.Linq;
using System.Threading.Tasks;

namespace Soccer.Web.Data.Entities
{
    public class TeamEntity
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The field {0}  can not have more than {1} characters.")]
        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Name { get; set; }

        [Display(Name = "Logo")]
        public string LogoPath { get; set; }

        [Display(Name = "Logo")]
        public string LogoFullPath => string.IsNullOrEmpty(LogoPath)
        ? "https://soccerwebcarolinalopera.azurewebsites.net//images/noimage.png"
        : $"https://soccerwebcarolinalopera.azurewebsites.net{LogoPath.Substring(1)}";

        public ICollection<GroupDetailEntity> GroupDetails { get; set; }

        public ICollection<UserEntity> Users { get; set; }

    }
    namespace Soccer.Web.Controllers.API
    {
        [Route("api/[controller]")]
        [ApiController]
        public class TeamsController : ControllerBase
        {
            private readonly DataContext _context;

            public TeamsController(DataContext context)
            {
                _context = context;
            }

            [HttpGet]
            public IEnumerable<TeamEntity> GetTeams()
            {
                return _context.Teams;
            }

            [HttpGet("{id}")]
            public async Task<IActionResult> GetTeamEntity([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var teamEntity = await _context.Teams.FindAsync(id);

                if (teamEntity == null)
                {
                    return NotFound();
                }

                return Ok(teamEntity);
            }

            [HttpPut("{id}")]
            public async Task<IActionResult> PutTeamEntity([FromRoute] int id, [FromBody] TeamEntity teamEntity)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (id != teamEntity.Id)
                {
                    return BadRequest();
                }

                _context.Entry(teamEntity).State = EntityState.Modified;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TeamEntityExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }

                return NoContent();
            }

            [HttpPost]
            public async Task<IActionResult> PostTeamEntity([FromBody] TeamEntity teamEntity)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                _context.Teams.Add(teamEntity);
                await _context.SaveChangesAsync();

                return CreatedAtAction("GetTeamEntity", new { id = teamEntity.Id }, teamEntity);
            }

            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteTeamEntity([FromRoute] int id)
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                TeamEntity teamEntity = await _context.Teams.FindAsync(id);
                if (teamEntity == null)
                {
                    return NotFound();
                }

                _context.Teams.Remove(teamEntity);
                await _context.SaveChangesAsync();

                return Ok(teamEntity);
            }

            private bool TeamEntityExists(int id)
            {
                return _context.Teams.Any(e => e.Id == id);
            }
        }
    }


}
