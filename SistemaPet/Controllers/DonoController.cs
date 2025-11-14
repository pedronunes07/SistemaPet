using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaPet.Data;
using SistemaPet.Models;

namespace SistemaPet.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DonoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DonoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/dono
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Dono>>> GetDonos()
        {
            return await _context.Donos
                .Include(d => d.Pets)
                .ToListAsync();
        }

        // GET: api/dono/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Dono>> GetDono(int id)
        {
            var dono = await _context.Donos
                .Include(d => d.Pets)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dono == null)
            {
                return NotFound();
            }

            return dono;
        }

        // POST: api/dono
        [HttpPost]
        public async Task<ActionResult<Dono>> PostDono(Dono dono)
        {
            _context.Donos.Add(dono);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDono), new { id = dono.Id }, dono);
        }

        // PUT: api/dono/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDono(int id, Dono dono)
        {
            if (id != dono.Id)
            {
                return BadRequest();
            }

            _context.Entry(dono).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DonoExists(id))
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

        // DELETE: api/dono/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDono(int id)
        {
            var dono = await _context.Donos
                .Include(d => d.Pets)
                .FirstOrDefaultAsync(d => d.Id == id);

            if (dono == null)
            {
                return NotFound();
            }

            // Remove os pets associados primeiro
            if (dono.Pets != null && dono.Pets.Any())
            {
                _context.Pets.RemoveRange(dono.Pets);
            }

            _context.Donos.Remove(dono);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DonoExists(int id)
        {
            return _context.Donos.Any(e => e.Id == id);
        }
    }
}

