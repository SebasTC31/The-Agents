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
    }
}
