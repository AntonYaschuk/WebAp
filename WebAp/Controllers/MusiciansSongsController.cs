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
    public class MusiciansSongsController : ControllerBase
    {
        private readonly DBMusicContext _context;

        public MusiciansSongsController(DBMusicContext context)
        {
            _context = context;
        }

        // GET: api/MusiciansSongs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusiciansSongs>>> GetMusiciansSongs()
        {
            return await _context.MusiciansSongs.ToListAsync();
        }

        // GET: api/MusiciansSongs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusiciansSongs>> GetMusiciansSongs(int id)
        {
            var musiciansSongs = await _context.MusiciansSongs.FindAsync(id);

            if (musiciansSongs == null)
            {
                return NotFound();
            }

            return musiciansSongs;
        }

        // PUT: api/MusiciansSongs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusiciansSongs(int id, MusiciansSongs musiciansSongs)
        {
            if (id != musiciansSongs.Id)
            {
                return BadRequest();
            }

            _context.Entry(musiciansSongs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusiciansSongsExists(id))
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

        // POST: api/MusiciansSongs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MusiciansSongs>> PostMusiciansSongs(MusiciansSongs musiciansSongs)
        {
            _context.MusiciansSongs.Add(musiciansSongs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusiciansSongs", new { id = musiciansSongs.Id }, musiciansSongs);
        }

        // DELETE: api/MusiciansSongs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MusiciansSongs>> DeleteMusiciansSongs(int id)
        {
            var musiciansSongs = await _context.MusiciansSongs.FindAsync(id);
            if (musiciansSongs == null)
            {
                return NotFound();
            }

            _context.MusiciansSongs.Remove(musiciansSongs);
            await _context.SaveChangesAsync();

            return musiciansSongs;
        }

        private bool MusiciansSongsExists(int id)
        {
            return _context.MusiciansSongs.Any(e => e.Id == id);
        }
    }
}
