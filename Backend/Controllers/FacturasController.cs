using Backend.DAL;
using Backend.DAL.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturasController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public FacturasController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/Facturas")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFacturas()
        {
            var facturas = await _context.Facturas.ToListAsync();

            if (facturas == null) return NotFound();

            return facturas;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Factura>> GetFactura(long id)
        {
            var factura = await _context.Facturas.FirstOrDefaultAsync(f => f.Id == id);

            if (factura == null) return NotFound();

            return Ok(factura);
        }

        [HttpGet("/ByService/{idServicio}")]
        public async Task<ActionResult<Factura>> GetFacturaByIdService(long idServicio)
        {
            var factura = await _context.Facturas.FirstOrDefaultAsync(f => f.IdServicio == idServicio);

            if (factura == null) return NotFound();

            return Ok(factura);
        }

        [HttpPost]
        public async Task<ActionResult<Factura>> PostFactura(Factura factura)
        {
            _context.Facturas.Add(factura);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetFactura), new { id = factura.Id }, factura);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFactura(long id, Factura factura)
        {
            if (id != factura.Id)
            {
                return BadRequest();
            }

            _context.Entry(factura).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacturaExists(id))
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
        public async Task<IActionResult> DeleteFactura(long id, long idFactura)
        {
            var factura = await _context.Facturas.FindAsync(id, idFactura);
            if (factura == null)
            {
                return NotFound();
            }

            _context.Facturas.Remove(factura);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool FacturaExists(long id)
        {
            throw new NotImplementedException();
        }

    }
}
