using Backend.DAL;
using Backend.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController: ControllerBase
    {
        private readonly DataBaseContext _context;

        public PacientesController(DataBaseContext context)
        {
            _context = context;
        }
       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Paciente>>> GetPacientes()
        {
            var pacientes = await _context.Pacientes.ToListAsync();

            if (pacientes == null || !pacientes.Any())
            {
                return NotFound();
            }

            return pacientes;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Paciente>> GetPacienteById(long id)
        {
            var paciente = await _context.Pacientes.FindAsync(id);

            if (paciente == null)
            {
                return NotFound();
            }

            return paciente;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaciente(long id, Paciente paciente)
        {
            if (id != paciente.Id)
            {
                return BadRequest();
            }

            _context.Entry(paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(id))
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

        [HttpGet("{idPaciente}/servicios/{idServicio}")]
        public async Task<ActionResult<Servicio>> ConsultarServicio(long idPaciente, long idServicio)
        {
            // Llamamos al método Get del controlador de Servicios para consultar el servicio por ID
            var servicioRespuesta = await new ServiciosController(_context).GetGerente(idServicio);
            if (servicioRespuesta.Result is NotFoundResult)
            {
                return NotFound("Servicio no encontrado");
            }

            return (ActionResult<Servicio>)servicioRespuesta.Result;
        }

        [HttpDelete("{idPaciente}/servicios/{idServicio}")]
        public async Task<IActionResult> CancelarServicio(long idPaciente, long idServicio)
        {
            var paciente = await _context.Pacientes.Include(p => p.Servicios).FirstOrDefaultAsync(p => p.Id == idPaciente);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado");
            }

            var servicio = paciente.Servicios.FirstOrDefault(s => s.Id == idServicio);

            if (servicio == null)
            {
                return NotFound("Servicio no encontrado para este paciente");
            }

            return await DeleteServicio(idServicio);
        }
        // Método DeleteServicio 
        private async Task<IActionResult> DeleteServicio(long id)
        {
            var servicio = await _context.Servicios.FindAsync(id);
            if (servicio == null)
            {
                return NotFound();
            }

            _context.Servicios.Remove(servicio);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("{idPaciente}/servicios/{idServicio}")]
        public async Task<IActionResult> ReprogramarServicio(long idPaciente, long idServicio, DateTime nuevaFecha)
        {
            var paciente = await _context.Pacientes.Include(p => p.Servicios).FirstOrDefaultAsync(p => p.Id == idPaciente);

            if (paciente == null)
            {
                return NotFound("Paciente no encontrado");
            }

            var servicio = paciente.Servicios.FirstOrDefault(s => s.Id == idServicio);

            if (servicio == null)
            {
                return NotFound("Servicio no encontrado para este paciente");
            }

            // Actualizar la fecha del servicio con la nueva fecha proporcionada
            servicio.Fecha = nuevaFecha;
 
            await _context.SaveChangesAsync();
            return NoContent();
        }
        private bool PacienteExists(long id)
        {
            throw new NotImplementedException();
        }

    }
}
