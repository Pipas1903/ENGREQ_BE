using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoProducerController : ControllerBase
    {
        private readonly ICoProducerService _coProducerService;

        public CoProducerController(ICoProducerService coProducerService)
        {
            _coProducerService = coProducerService;
        }

        // GET: api/CoProducer/{userId}
        [HttpGet("{userId}")]
        public async Task<ActionResult<CoProducer>> GetCoProducer(int userId)
        {
            var coProducer = await _coProducerService.GetCoProducerByUserIdAsync(userId);

            if (coProducer == null)
            {
                return NotFound();
            }

            return Ok(coProducer);
        }

        // POST: api/CoProducer
        [HttpPost]
        public async Task<ActionResult<CoProducer>> CreateCoProducer(CoProducerCreateDto coProducerDto)
        {
            var coProducer = await _coProducerService.CreateCoProducerAsync(coProducerDto);

            return CreatedAtAction(nameof(GetCoProducer), new { userId = coProducer.UserId }, coProducer);
        }

        // PUT: api/CoProducer/{userId}
        [HttpPut("{userId}")]
        public async Task<IActionResult> UpdateCoProducer(int userId, CoProducerUpdateDto coProducerUpdateDto)
        {
            var updatedCoProducer = await _coProducerService.UpdateCoProducerAsync(userId, coProducerUpdateDto);

            if (updatedCoProducer == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/CoProducer/{userId}
        [HttpDelete("{userId}")]
        public async Task<IActionResult> DeleteCoProducer(int userId)
        {
            var success = await _coProducerService.DeleteCoProducerAsync(userId);

            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
