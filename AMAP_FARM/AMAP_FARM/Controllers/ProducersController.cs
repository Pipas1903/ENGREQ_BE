using Microsoft.AspNetCore.Mvc;
using AMAP_FARM.Models;
using Microsoft.EntityFrameworkCore;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor to inject AppDbContext
        public ProducerController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Producer
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Producer>>> GetProducers()
        {
            var producers = await _context.Producers.ToListAsync();
            return Ok(producers);
        }

        // GET: api/Producer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Producer>> GetProducer(int id)
        {
            var producer = await _context.Producers.FindAsync(id);

            if (producer == null)
            {
                return NotFound();
            }

            return Ok(producer);
        }

        // POST: api/Producer
        [HttpPost]
        public async Task<ActionResult<Producer>> CreateProducer(Producer producer)
        {
            // Ensure that RoleId and other required properties are set correctly
            if (producer == null)
            {
                return BadRequest("Producer data is invalid.");
            }

            // Set any additional logic or validation here

            // Add the new producer to the context
            _context.Producers.Add(producer);

            try
            {
                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                // Handle potential database errors (e.g., duplicate emails, etc.)
                return StatusCode(500, "Internal server error while creating producer.");
            }

            return CreatedAtAction(nameof(GetProducer), new { id = producer.Id }, producer);
        }

        // PUT: api/Producer/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProducer(int id, Producer producer)
        {
            if (id != producer.Id)
            {
                return BadRequest("Producer ID mismatch.");
            }

            // Ensure producer exists before updating
            var existingProducer = await _context.Producers.FindAsync(id);
            if (existingProducer == null)
            {
                return NotFound();
            }

            // Update the properties (you can add any custom validation or logic here)
            existingProducer.FarmName = producer.FarmName;
            existingProducer.Location = producer.Location;
            existingProducer.ContactNumber = producer.ContactNumber;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return StatusCode(500, "Internal server error while updating producer.");
            }

            return NoContent(); // Return status code 204 if successful
        }

        // DELETE: api/Producer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProducer(int id)
        {
            var producer = await _context.Producers.FindAsync(id);
            if (producer == null)
            {
                return NotFound();
            }

            _context.Producers.Remove(producer);
            await _context.SaveChangesAsync();

            return NoContent(); // Return status code 204 for successful deletion
        }
    }
}
