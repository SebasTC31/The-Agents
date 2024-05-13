using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DAL;
using Backend.DAL.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequieresController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public RequieresController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Requiere>>> GetRequiere()
        {
            var requiere = await _context.Requieres.ToListAsync();

            if (requiere == null || !requiere.Any())
            {
                return NotFound();
            }

            return requiere;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Requiere>> GetRequiereById(long id)
        {
            var requiere = await _context.Requieres.FindAsync(id);

            if (requiere == null)
            {
                return NotFound();
            }

            return requiere;
        }

        [HttpPost]
        public async Task<ActionResult<Requiere>> PostRequiere(Requiere requiere)
        {
            _context.Requieres.Add(requiere);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRequiereById", new { id = requiere.Id }, requiere);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutRequiere(long id, Requiere requiere)
        {
            if (id != requiere.Id)
            {
                return BadRequest();
            }

            _context.Entry(requiere).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RequiereExists(id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRequiere(long id)
        {
            var requiere = await _context.Requieres.FindAsync(id);
            if (requiere == null)
            {
                return NotFound();
            }

            _context.Requieres.Remove(requiere);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RequiereExists(long id)
        {
            return _context.Requieres.Any(e => e.Id == id);
        }
    }
}

