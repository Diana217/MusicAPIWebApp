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
    public class CountryOfOriginsController : ControllerBase
    {
        private readonly MusicAPIContext _context;

        public CountryOfOriginsController(MusicAPIContext context)
        {
            _context = context;
        }

        // GET: api/CountryOfOrigins
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryOfOrigin>>> GetCountryOfOrigins()
        {
          if (_context.CountryOfOrigins == null)
          {
              return NotFound();
          }
            return await _context.CountryOfOrigins.ToListAsync();
        }

        // GET: api/CountryOfOrigins/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryOfOrigin>> GetCountryOfOrigin(int id)
        {
          if (_context.CountryOfOrigins == null)
          {
              return NotFound();
          }
            var countryOfOrigin = await _context.CountryOfOrigins.FindAsync(id);

            if (countryOfOrigin == null)
            {
                return NotFound();
            }

            return countryOfOrigin;
        }

        // PUT: api/CountryOfOrigins/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryOfOrigin(int id, CountryOfOrigin countryOfOrigin)
        {
            if (id != countryOfOrigin.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryOfOrigin).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryOfOriginExists(id))
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

        // POST: api/CountryOfOrigins
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryOfOrigin>> PostCountryOfOrigin(CountryOfOrigin countryOfOrigin)
        {
          if (_context.CountryOfOrigins == null)
          {
              return Problem("Entity set 'MusicAPIContext.CountryOfOrigins'  is null.");
          }
            _context.CountryOfOrigins.Add(countryOfOrigin);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryOfOrigin", new { id = countryOfOrigin.Id }, countryOfOrigin);
        }

        // DELETE: api/CountryOfOrigins/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryOfOrigin(int id)
        {
            if (_context.CountryOfOrigins == null)
            {
                return NotFound();
            }
            var countryOfOrigin = await _context.CountryOfOrigins.FindAsync(id);
            if (countryOfOrigin == null)
            {
                return NotFound();
            }

            _context.CountryOfOrigins.Remove(countryOfOrigin);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryOfOriginExists(int id)
        {
            return (_context.CountryOfOrigins?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
