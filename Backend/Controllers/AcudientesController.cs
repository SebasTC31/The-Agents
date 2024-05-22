using Backend.DAL.Entities;
using Backend.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AcudientesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public AcudientesController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Acudiente>>> GetAcudientes()
        {
            var acudientes = await _context.Acudientes.ToListAsync();

            if (acudientes == null) return NotFound();

            return acudientes;
        }

      

        [HttpGet("{id}")]
        public async Task<ActionResult<Acudiente>> GetAcudienteById(long id)
        {
            var acudiente = await _context.Acudientes.FindAsync(id);

            if (acudiente == null)
            {
                return NotFound();
            }

            return acudiente;
        }

        [HttpPost]
        public async Task<ActionResult<Acudiente>> PostAcudiente(Acudiente acudiente)
        {
            _context.Acudientes.Add(acudiente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcudienteById", new { id = acudiente.Id }, acudiente);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcudiente(long id, Acudiente acudiente)
        {
            if (id != acudiente.Id)
            {
                return BadRequest();
            }

            _context.Entry(acudiente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcudienteExists(id))
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
        public async Task<IActionResult> DeleteAcudiente(long id)
        {
            var acudiente = await _context.Acudientes.FindAsync(id);
            if (acudiente == null)
            {
                return NotFound();
            }

            _context.Acudientes.Remove(acudiente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AcudienteExists(long id)
        {
            return _context.Acudientes.Any(a => a.Id == id);
        }
    }
}
