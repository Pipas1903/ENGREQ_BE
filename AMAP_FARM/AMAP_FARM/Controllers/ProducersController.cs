using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProducerController : ControllerBase
    {
        private readonly IProducerService _producerService;

        public ProducerController(IProducerService producerService)
        {
            _producerService = producerService;
        }

        // GET: api/Producer/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<Producer>> GetProducer(int userId)
        {
            var producer = await _producerService.GetProducerByUserIdAsync(userId);

            if (producer == null)
            {
                return NotFound();
            }

            return Ok(producer);
        }

        // POST: api/Producer
        [HttpPost]
        public async Task<ActionResult<Producer>> CreateProducer(ProducerCreateDto producerDto)
        {
            var producer = await _producerService.CreateProducerAsync(producerDto);

            return CreatedAtAction(nameof(GetProducer), new { userId = producer.UserId }, producer);
        }

        // PUT: api/Producer/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateProducer(int userId, ProducerUpdateDto producerUpdateDto)
        {
            var updatedProducer = await _producerService.UpdateProducerAsync(userId, producerUpdateDto);

            if (updatedProducer == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Producer/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteProducer(int userId)
        {
            var success = await _producerService.DeleteProducerAsync(userId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
