using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrailStatus.Models;

namespace TrailStatus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrailsController : ControllerBase
    {
        private readonly TrailsContext _context;

        public TrailsController(TrailsContext context)
        {
            _context = context;

            if (_context.Trail.Count() == 0)
            {
                // Create a new TodoItem if collection is empty,
                // which means you can't delete all TodoItems.
                _context.Trail.Add(new Trail { Name = "Magic Mystery Trail" });
                _context.SaveChanges();
            }
        }

        // GET: api/Trails
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trail>>> GetTrails()
        {
            return await _context.Trail.ToListAsync();
        }

        // GET: api/Trails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trail>> GetTrail(long id)
        {
            var trail = await _context.Trail.FindAsync(id);

            if (trail == null)
            {
                return NotFound();
            }

            return trail;
        }

        // POST: api/Trails
        [HttpPost]
        public async Task<ActionResult<Trail>> PostTrail(Trail trail)
        {
            _context.Trail.Add(trail);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTrail), new { id = trail.Id }, trail);
        }

        // PUT: api/Trails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrail(long id, Trail trail)
        {
            if (id != trail.Id)
            {
                return BadRequest();
            }

            _context.Entry(trail).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Trails/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrail(long id)
        {
            var trail = await _context.Trail.FindAsync(id);

            if (trail == null)
            {
                return NotFound();
            }

            _context.Trail.Remove(trail);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}