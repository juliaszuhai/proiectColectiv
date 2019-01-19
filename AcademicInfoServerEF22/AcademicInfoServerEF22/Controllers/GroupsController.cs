using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GroupsController : ControllerBase
    {
        private readonly AcademicInfoContext _context;

        public GroupsController(AcademicInfoContext context)
        {
            _context = context;
        }

        // GET: api/Groups
        [HttpGet]
        public IEnumerable<Group> GetGroup()
        {
            return _context.Group;
        }

        // GET: api/Groups/<discipline>
        [HttpGet("{discipline}")]
        public IActionResult GetGroupsForDiscipline([FromRoute] string discipline)
        {
            // Retrieve a set containing all the groups that have at least 1 student enrolled to the given discipline
            HashSet<string> groups = new HashSet<string>();
            groups = _context.Student.Where(
                s => s.Grades.Where(
                    gtd => gtd.Discipline.Nume.Equals(discipline)
                ).FirstOrDefault() != null).Select(
                s => s.FacultiesEnrolled
            ).SelectMany(fe => fe).Select(fe => fe.Group.GroupName).ToHashSet();

            // Return the set of groups
            return Ok(groups);
        }

        // GET: api/Groups/Get/<specializare>
        [HttpGet("Get/{an}/{numeSpecializare}")]
        public IActionResult GetGroupsForSpecializare([FromRoute] string an, [FromRoute] string numeSpecializare)
        {
            Specializare specializare = _context.Specializare.Where(
                s => s.Nume.Equals(numeSpecializare)
            ).FirstOrDefault();

            if (specializare == null)
            {
                Dictionary<string, string> err = new Dictionary<string, string>();
                err.Add("error", String.Format("There is no specializare named: '{0}'!", numeSpecializare));
                return Ok(err);
            }

            List<Group> groups = _context.Group.Where(g => g.NumeSpecializare.Equals(numeSpecializare)).ToList();

            List<string> response = new List<string>();

            foreach (var g in groups)
                if (g.GroupName[1] == char.Parse(an))
                    response.Add(g.GroupName);

            return Ok(response);
        }

        // PUT: api/Groups/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroup([FromRoute] int id, [FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @group.Id)
            {
                return BadRequest();
            }

            _context.Entry(@group).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GroupExists(id))
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

        // POST: api/Groups
        [HttpPost]
        public async Task<IActionResult> PostGroup([FromBody] Group @group)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Group.Add(@group);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGroup", new { id = @group.Id }, @group);
        }

        // DELETE: api/Groups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroup([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var @group = await _context.Group.FindAsync(id);
            if (@group == null)
            {
                return NotFound();
            }

            _context.Group.Remove(@group);
            await _context.SaveChangesAsync();

            return Ok(@group);
        }

        private bool GroupExists(int id)
        {
            return _context.Group.Any(e => e.Id == id);
        }
    }
}