using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicAPIWebApp.Models;

namespace MusicAPIWEbApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusicalInstrumentsController : ControllerBase
    {
        private readonly MusicAPIContext _context;

        public MusicalInstrumentsController(MusicAPIContext context)
        {
            _context = context;
        }

        // GET: api/MusicalInstruments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MusicalInstrument>>> GetMusicalInstruments()
        {
          if (_context.MusicalInstruments == null)
          {
              return NotFound();
          }
            return await _context.MusicalInstruments.ToListAsync();
        }

        // GET: api/MusicalInstruments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MusicalInstrument>> GetMusicalInstrument(int id)
        {
          if (_context.MusicalInstruments == null)
          {
              return NotFound();
          }
            var musicalInstrument = await _context.MusicalInstruments.FindAsync(id);

            if (musicalInstrument == null)
            {
                return NotFound();
            }

            return musicalInstrument;
        }

        // PUT: api/MusicalInstruments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMusicalInstrument(int id, MusicalInstrument musicalInstrument)
        {
            if (id != musicalInstrument.Id)
            {
                return BadRequest();
            }

            _context.Entry(musicalInstrument).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MusicalInstrumentExists(id))
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

        // POST: api/MusicalInstruments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MusicalInstrument>> PostMusicalInstrument(MusicalInstrument musicalInstrument)
        {
          if (_context.MusicalInstruments == null)
          {
              return Problem("Entity set 'MusicAPIContext.MusicalInstruments'  is null.");
          }
            _context.MusicalInstruments.Add(musicalInstrument);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMusicalInstrument", new { id = musicalInstrument.Id }, musicalInstrument);
        }

        // DELETE: api/MusicalInstruments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMusicalInstrument(int id)
        {
            if (_context.MusicalInstruments == null)
            {
                return NotFound();
            }
            var musicalInstrument = await _context.MusicalInstruments.FindAsync(id);
            if (musicalInstrument == null)
            {
                return NotFound();
            }

            _context.MusicalInstruments.Remove(musicalInstrument);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MusicalInstrumentExists(int id)
        {
            return (_context.MusicalInstruments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
