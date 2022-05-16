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
    public class InstrumentPerformersController : ControllerBase
    {
        private readonly MusicAPIContext _context;

        public InstrumentPerformersController(MusicAPIContext context)
        {
            _context = context;
        }

        // GET: api/InstrumentPerformers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstrumentPerformer>>> GetInstrumentPerformers()
        {
          if (_context.InstrumentPerformers == null)
          {
              return NotFound();
          }
            return await _context.InstrumentPerformers.ToListAsync();
        }

        // GET: api/InstrumentPerformers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstrumentPerformer>> GetInstrumentPerformer(int id)
        {
          if (_context.InstrumentPerformers == null)
          {
              return NotFound();
          }
            var instrumentPerformer = await _context.InstrumentPerformers.FindAsync(id);

            if (instrumentPerformer == null)
            {
                return NotFound();
            }

            return instrumentPerformer;
        }

        // PUT: api/InstrumentPerformers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstrumentPerformer(int id, InstrumentPerformer instrumentPerformer)
        {
            if (id != instrumentPerformer.Id)
            {
                return BadRequest();
            }

            _context.Entry(instrumentPerformer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InstrumentPerformerExists(id))
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

        // POST: api/InstrumentPerformers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstrumentPerformer>> PostInstrumentPerformer(InstrumentPerformer instrumentPerformer)
        {
          if (_context.InstrumentPerformers == null)
          {
              return Problem("Entity set 'MusicAPIContext.InstrumentPerformers'  is null.");
          }
            _context.InstrumentPerformers.Add(instrumentPerformer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInstrumentPerformer", new { id = instrumentPerformer.Id }, instrumentPerformer);
        }

        // DELETE: api/InstrumentPerformers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstrumentPerformer(int id)
        {
            if (_context.InstrumentPerformers == null)
            {
                return NotFound();
            }
            var instrumentPerformer = await _context.InstrumentPerformers.FindAsync(id);
            if (instrumentPerformer == null)
            {
                return NotFound();
            }

            _context.InstrumentPerformers.Remove(instrumentPerformer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstrumentPerformerExists(int id)
        {
            return (_context.InstrumentPerformers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
