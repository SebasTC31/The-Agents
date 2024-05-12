using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DAL;
using Backend.DAL.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public EmpleadosController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/Usuarios")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            var empleados = await _context.Empleados.ToListAsync();

            if (empleados == null) return NotFound();

            return empleados;
        }

        [HttpGet("{usuarioId}")]
        public async Task<IActionResult> GetEmpleado(long usuarioId)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);

            if (empleado == null) return NotFound();

            return Ok(empleado);
        }

        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.Id }, empleado);
        }

        [HttpPut("{usuarioId}")]
        public async Task<IActionResult> PutEmpleado(long usuarioId, Empleado empleado)
        {
            if (usuarioId != empleado.UsuarioId)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadoExists(usuarioId))
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
        public async Task<IActionResult> DeleteEmpleado(long usuarioId)
        {
            var empleado = await _context.Empleados.FirstOrDefaultAsync(e => e.UsuarioId == usuarioId);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpleadoExists(long usuarioId)
        {
            return _context.Empleados.Any(e => e.UsuarioId == usuarioId);
        }

    }
}
