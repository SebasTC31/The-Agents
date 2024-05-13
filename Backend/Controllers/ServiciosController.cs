using Backend.DAL;
using Backend.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiciosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public ServiciosController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/Servicios")]
        public async Task<ActionResult<IEnumerable<Servicio>>> GetServicios()
        {
            var servicios = await _context.Servicios.ToListAsync();

            if (servicios == null) return NotFound();

            return servicios;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Gerente>> GetGerente(long id)
        {
            var servicio = await _context.Servicios.FirstOrDefaultAsync(s => s.Id == id);

            if (servicio == null) return NotFound();

            return Ok(servicio);
        }

        [HttpPost]
        public async Task<ActionResult<Gerente>> PostServicio(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGerente), new { id = servicio.Id }, servicio);
        }
    }
}
