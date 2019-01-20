using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22EF22.Controllers
{
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/Specializari")]
    public class SpecializariController : Controller
    {
        private readonly AcademicInfoContext _context;

        public SpecializariController(AcademicInfoContext context)
        {
            _context = context;
        }

        // GET: api/Specializari
        [HttpGet]
        public IEnumerable<Specializare> GetSpecializare()
        {
            return _context.Specializare.ToArray();
        }

        // GET: api/Specializari/<department>
        [HttpGet("{department}")]
        public IActionResult GetSpecializariForDepartments([FromRoute] string department)
        {
            Department d = _context.Department.Where(dep => dep.Name == department).FirstOrDefault();

            if (d == null)
            {
                Dictionary<string, string> err = new Dictionary<string, string>();
                err.Add("error", String.Format("There is no department named: '{0}'!", department));
                return Json(err);
            }

            List<Specializare> specializari = _context.Specializare.Where(
                s => s.DepartmentName.Equals(d.Name)
            ).ToList();

            List<string> response = new List<string>();

            foreach(var s in specializari)
                response.Add(s.Nume);

            return Json(response);
        }

        // PUT: api/Specializari/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpecializare([FromRoute] int id, [FromBody] Specializare specializare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != specializare.Id)
            {
                return BadRequest();
            }

            _context.Entry(specializare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpecializareExists(id))
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

        // POST: api/Specializari
        [HttpPost]
        public async Task<IActionResult> PostSpecializare([FromBody] Specializare specializare)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Specializare.Add(specializare);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpecializare", new { id = specializare.Id }, specializare);
        }

        // DELETE: api/Specializari/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpecializare([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var specializare = await _context.Specializare.SingleOrDefaultAsync(m => m.Id == id);
            if (specializare == null)
            {
                return NotFound();
            }

            _context.Specializare.Remove(specializare);
            await _context.SaveChangesAsync();

            return Ok(specializare);
        }

        private bool SpecializareExists(int id)
        {
            return _context.Specializare.Any(e => e.Id == id);
        }
    }
}