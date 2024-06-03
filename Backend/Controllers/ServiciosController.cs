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
            var servicio = await _context.Servicios.Include(s => s.Factura).FirstOrDefaultAsync(s => s.Id == id);

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
        public async Task<ActionResult<Servicio>> CreateServicio(Servicio servicioDto)
        {
            // Crear un nuevo objeto Servicio basado en los datos de la solicitud DTO
            var servicio = new Servicio
            {
                Fecha = servicioDto.Fecha,
                TipoServicio = servicioDto.TipoServicio,
                Precio = servicioDto.Precio,
                Descripcion = servicioDto.Descripcion,
                CantServicio = servicioDto.CantServicio,
                DescDiagnostico = servicioDto.DescDiagnostico,
                PrescDiagnostico = servicioDto.PrescDiagnostico,
                // Cargar el Empleado existente desde la base de datos usando el ID proporcionado
                IdEmpleado = servicioDto.IdEmpleado,
                //Empleado = await _context.Empleados.FindAsync(servicioDto.IdEmpleado),
                // Crear un nuevo objeto Factura basado en los datos de la solicitud DTO
            };

            _context.Servicios.Add(servicio);
            await _context.SaveChangesAsync();

            servicioDto.Factura.IdServicio = servicio.Id;

            var factura = new Factura
            {
                Id = servicioDto.Factura.Id,
                IdServicio = servicioDto.Id,
                Fecha = servicioDto.Factura.Fecha,
                ValorTotal = servicioDto.Factura.ValorTotal,
                MetodoPago = servicioDto.Factura.MetodoPago,
                Descripcion = servicioDto.Factura.Descripcion,
                Estado = servicioDto.Factura.Estado,
                // Cargar el Acudiente existente desde la base de datos usando el ID proporcionado
                AcudienteId = servicioDto.Factura.AcudienteId,
                Acudiente = await _context.Acudientes.FindAsync(servicioDto.Factura.AcudienteId)
            };

            factura.IdServicio = servicio.Id;

            // Agregar el nuevo Servicio al contexto y guardar los cambios en la base de datos
            _context.Facturas.Add(factura);
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
