using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AcademicInfoServerEF22EF22.Models;

namespace AcademicInfoServerEF22EF22.Controllers
{
    [Produces("application/json")]
    [Route("api/Admins")]
    public class AdminsController : Controller
    {
        private readonly AcademicInfoContext _context;
        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public AdminsController(AcademicInfoContext context)
        {

            _context = context;
            PopulateDatabase();
        }

        public void PopulateDatabase()
        {
            //Try to retrieve the Admins with the Username 'a1' and 'a2'
            Admin a1 = _context.Admin.Where(a => a.Username.Equals("a1")).FirstOrDefault();
            Admin a2 = _context.Admin.Where(a => a.Username.Equals("a2")).FirstOrDefault();

            //If the first admin is not present into the DB, then we must add him
            if (a1 == null)
            {
                //Generate salt
                byte[] saltNumber = new byte[10];
                rngCsp.GetBytes(saltNumber);
                String saltString = System.Text.Encoding.Default.GetString(saltNumber);

                //Encrypt password
                String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");

                //Add the admin 'a1'
                _context.Admin.Add(new Admin() {
                    Username = "a1",
                    Adresa = "Str. Fericirii, Nr. 10, Ap. 10",
                    Email = "admin1@yahoo.com",
                    NumarTelefon = "0711111111",
                    Nume = "Admin",
                    Prenume = "1",
                    UserType = UserType.ADMIN,
                    Password = password,
                    Salt = saltString
                });
                _context.SaveChanges();
            }

            //If the second admin is not present into the DB, then we must add him
            if (a2 == null)
            {
                //Generate salt
                byte[] saltNumber = new byte[10];
                rngCsp.GetBytes(saltNumber);
                String saltString = System.Text.Encoding.Default.GetString(saltNumber);

                //Encrypt password
                String password = BCrypt.Net.BCrypt.HashPassword(saltString + "pass");

                //Add the admin 'a2'
                _context.Admin.Add(new Admin()
                {
                    Username = "a2",
                    Adresa = "Str. Nefericirii, Nr. 13, Ap. 66",
                    Email = "admin2@yahoo.com",
                    NumarTelefon = "0722222222",
                    Nume = "Admin",
                    Prenume = "2",
                    UserType = UserType.ADMIN,
                    Password = password,
                    Salt = saltString
                });
                _context.SaveChanges();
            }
        }

        // GET: api/Admins
        [HttpGet]
        public IEnumerable<Admin> GetAdmin()
        {
            return _context.Admin;
        }

        // GET: api/Admins/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAdmin([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.Admin.SingleOrDefaultAsync(m => m.Username == id);

            if (admin == null)
            {
                return NotFound();
            }

            return Ok(admin);
        }

        // PUT: api/Admins/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAdmin([FromRoute] string id, [FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != admin.Username)
            {
                return BadRequest();
            }

            _context.Entry(admin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AdminExists(id))
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

        // POST: api/Admins
        [HttpPost]
        public async Task<IActionResult> PostAdmin([FromBody] Admin admin)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Admin.Add(admin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAdmin", new { id = admin.Username }, admin);
        }

        // DELETE: api/Admins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAdmin([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var admin = await _context.Admin.SingleOrDefaultAsync(m => m.Username == id);
            if (admin == null)
            {
                return NotFound();
            }

            _context.Admin.Remove(admin);
            await _context.SaveChangesAsync();

            return Ok(admin);
        }

        private bool AdminExists(string id)
        {
            return _context.Admin.Any(e => e.Username == id);
        }

    }
}