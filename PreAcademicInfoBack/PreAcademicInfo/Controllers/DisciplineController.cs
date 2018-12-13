using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PreAcademicInfo.Models;

namespace PreAcademicInfo.Controllers
{
    [Produces("application/json")]
    [Route("api/Discipline")]
    public class DisciplineController : Controller
    {
        private readonly StudentContext _context;

        public DisciplineController(StudentContext context)
        {
            _context = context;
        }

        // GET: api/Discipline
        [HttpGet]
        public IEnumerable<Discipline> GetDiscipline()
        {
            return _context.Discipline;
        }

        // GET: api/Discipline/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscipline([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discipline = await _context.Discipline.SingleOrDefaultAsync(m => m.Cod == id);

            if (discipline == null)
            {
                return NotFound();
            }

            return Ok(discipline);
        }

        // PUT: api/Discipline/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscipline([FromRoute] string id, [FromBody] Discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != discipline.Cod)
            {
                return BadRequest();
            }

            _context.Entry(discipline).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisciplineExists(id))
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

        // POST: api/Discipline
        [HttpPost]
        public async Task<IActionResult> PostDiscipline([FromBody] Discipline discipline)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Discipline.Add(discipline);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDiscipline", new { id = discipline.Cod }, discipline);
        }

        // DELETE: api/Discipline/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscipline([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var discipline = await _context.Discipline.SingleOrDefaultAsync(m => m.Cod == id);
            if (discipline == null)
            {
                return NotFound();
            }

            _context.Discipline.Remove(discipline);
            await _context.SaveChangesAsync();

            return Ok(discipline);
        }

        private bool DisciplineExists(string id)
        {
            return _context.Discipline.Any(e => e.Cod == id);
        }
    }
}