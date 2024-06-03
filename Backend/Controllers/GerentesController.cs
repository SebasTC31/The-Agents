using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DAL;
using Backend.DAL.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GerentesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public GerentesController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/Gerentes")]
        public async Task<ActionResult<IEnumerable<Gerente>>> GetEmpleados()
        {
            var gerentes = await _context.Gerentes.Include(g => g.Usuario).ToListAsync();

            if (gerentes == null) return NotFound();

            return gerentes;
        }

        [HttpGet("{usuarioId}")]
        public async Task<ActionResult<Gerente>> GetGerente(long usuarioId)
        {
            var gerente = await _context.Gerentes.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);

            if (gerente == null) return NotFound();

            return Ok(gerente);
        }

        [HttpPost]
        public async Task<ActionResult<Gerente>> PostGerente(Gerente gerente)
        {
            _context.Gerentes.Add(gerente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGerente), new { id = gerente.Id }, gerente);
        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> PutGerente(long usuarioId, Gerente gerente)
        {
            if (usuarioId != gerente.Id)
            {
                return BadRequest();
            }

            _context.Entry(gerente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GerenteExists(usuarioId))
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

        [HttpDelete("{usuarioId}")]
        public async Task<IActionResult> DeleteGerente(long usuarioId)
        {
            var gerente = await _context.Gerentes.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);
            if (gerente == null)
            {
                return NotFound();
            }

            _context.Gerentes.Remove(gerente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GerenteExists(long usuarioId)
        {
            return _context.Gerentes.Any(e => e.Id == usuarioId);
        }
    }
}
