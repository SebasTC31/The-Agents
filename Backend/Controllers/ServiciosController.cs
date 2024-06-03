using Backend.DAL;
using Backend.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task<ActionResult<Servicio>> GetServiciosById(long id)
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

            return CreatedAtAction(nameof(GetServiciosById), new { id = servicio.Id }, servicio);
        }

        [HttpPost("/Create")]
        public async Task<ActionResult<Servicio>> CreateServicio(Servicio servicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Obtener el empleado existente de la base de datos
            var empleado = await _context.Empleados.FindAsync(servicio.IdEmpleado.FirstOrDefault().Id);

            // Verificar si el empleado existe
            if (empleado == null)
            {
                return BadRequest("El empleado especificado no existe.");
            }

            // Asociar el empleado al servicio
            servicio.IdEmpleado = new List<Empleado> { empleado };

            // Crear una factura asociada al nuevo servicio
            Factura factura = new Factura
            {
                Fecha = DateTime.Now,
                ValorTotal = servicio.Precio * servicio.CantServicio,
                MetodoPago = "Efectivo", // Puedes cambiar esto según lo que necesites
                Descripcion = "Factura por servicio",
                Estado = "Pendiente", // O cualquier otro estado predeterminado
                Servicios = new List<Servicio> { servicio } // Asociar el servicio a la factura
            };

            // Agregar la factura a la base de datos
            _context.Facturas.Add(factura);

            // Agregar el nuevo servicio a la base de datos
            _context.Servicios.Add(servicio);

            // Crear los requerimientos asociados al servicio
            foreach (var requerimiento in servicio.Requiere)
            {
                _context.Requieres.Add(requerimiento);
            }

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetServiciosById), new { id = servicio.Id }, servicio);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutServicio(long id, Servicio servicio)
        {
            if (id != servicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(servicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServicioExists(id))
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
        public async Task<IActionResult> DeleteServicio(long id)
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

        // Métodos adicionales para manejar las relaciones          //Mala relación en Servicios
        [HttpGet("{id}/empleados")]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleadosDelServicio(long id)
        {
            var empleados = await _context.Empleados.Where(e => e.Servicio.Any(s => s.Id == id)).ToListAsync();

            if (empleados == null)
            {
                return NotFound();
            }

            return empleados;
        }

        [HttpGet("{id}/factura")]
        public async Task<ActionResult<Factura>> GetFacturaDelServicio(long id)
        {
            var factura = await _context.Facturas.FirstOrDefaultAsync(f => f.Servicios.Any(s => s.Id == id));

            if (factura == null)
            {
                return NotFound();
            }

            return factura;
        }

        private bool ServicioExists(long id)
        {
            return _context.Servicios.Any(e => e.Id == id);
        }
    }
}
