using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.DAL;
using Backend.DAL.Entities;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public UsuariosController(DataBaseContext context)
        {
            _context = context;
        }

        [HttpGet, ActionName("Get")]
        [Route("Get/Usuarios")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuarios()
        {
            var usuarios = await _context.Usuarios.ToListAsync();

            if (usuarios == null) return NotFound();

            return usuarios;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null) return NotFound();

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> PostUsuario(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(long id, Usuario usuario)
        {
            if (id != usuario.Id) return BadRequest();

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id)) return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(long id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
                return NotFound();

            _context.Usuarios.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(long id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }

    }
}
// Si este comentario aparece, significa que si se está enviando los cambios al hacer push.