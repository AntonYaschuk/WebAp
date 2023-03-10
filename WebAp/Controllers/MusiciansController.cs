using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAp.Models;

namespace WebAp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {
        private readonly DBMusicContext _context;

        public MusiciansController(DBMusicContext context)
        {
            _context = context;
        }

        // GET: api/Musicians
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Musician>>> GetMusicians()
        {
            return await _context.Musicians.ToListAsync();
        }

        // GET: api/Musicians/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Musician>> GetMusician(int id)
        {
            var musician = await _context.Musicians.FindAsync(id);

            if (musician == null)
            {
                return NotFound();
            }

            return musician;
        }

        // PUT: api/Musicians/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusician(int id, Musician musician)
        {
            if (id != musician.Id)
            {
                return BadRequest();
            }

            _context.Entry(musician).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicianExists(id))
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

        // POST: api/Musicians
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Musician>> PostMusician(Musician musician)
        {
            _context.Musicians.Add(musician);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusician", new { id = musician.Id }, musician);
        }

        // DELETE: api/Musicians/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Musician>> DeleteMusician(int id)
        {
            var musician = await _context.Musicians.FindAsync(id);
            if (musician == null)
            {
                return NotFound();
            }

            _context.Musicians.Remove(musician);
            await _context.SaveChangesAsync();

            return musician;
        }

        private bool MusicianExists(int id)
        {
            return _context.Musicians.Any(e => e.Id == id);
        }
    }
}
