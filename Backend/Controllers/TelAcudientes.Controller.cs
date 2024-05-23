using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DAL;
using Backend.DAL.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TelAcudientesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public TelAcudientesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/TelAcudientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TelAcudiente>>> GetTelAcudientes()
        {
            var telAcudientes = await _context.TelAcudientes.ToListAsync();
            if (telAcudientes == null) return NotFound();

            return telAcudientes;
        }

        // GET: api/TelAcudientes
        [HttpGet("{idAcudiente}/{telefono}")]
        public async Task<ActionResult<TelAcudiente>> GetTelAcudiente(long idAcudiente, long telefono)
        {
            var telAcudiente = await _context.TelAcudientes
                                             .FirstOrDefaultAsync(t => t.IdAcudiente == idAcudiente && t.Telefono == telefono);

            if (telAcudiente == null) return NotFound();

            return telAcudiente;
        }

        // POST: api/TelAcudientes
        [HttpPost]
        public async Task<ActionResult<TelAcudiente>> PostTelAcudiente(TelAcudiente telAcudiente)
        {
            _context.TelAcudientes.Add(telAcudiente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTelAcudiente), new { idAcudiente = telAcudiente.IdAcudiente, telefono = telAcudiente.Telefono }, telAcudiente);
        }

        // PUT: api/TelAcudientes
        [HttpPut("{idAcudiente}/{telefono}")]
        public async Task<IActionResult> PutTelAcudiente(long idAcudiente, long telefono, TelAcudiente telAcudiente)
        {
            if (idAcudiente != telAcudiente.IdAcudiente || telefono != telAcudiente.Telefono)
            {
                return BadRequest();
            }

            _context.Entry(telAcudiente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelAcudienteExists(idAcudiente, telefono))
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

        // DELETE: api/TelAcudientes
        [HttpDelete("{idAcudiente}/{telefono}")]
        public async Task<IActionResult> DeleteTelAcudiente(long idAcudiente, long telefono)
        {
            var telAcudiente = await _context.TelAcudientes
                                             .FirstOrDefaultAsync(t => t.IdAcudiente == idAcudiente && t.Telefono == telefono);
            if (telAcudiente == null)
            {
                return NotFound();
            }

            _context.TelAcudientes.Remove(telAcudiente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TelAcudienteExists(long idAcudiente, long telefono)
        {
            return _context.TelAcudientes.Any(t => t.IdAcudiente == idAcudiente && t.Telefono == telefono);
        }
    }
}
