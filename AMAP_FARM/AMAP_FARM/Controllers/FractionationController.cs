using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FractionationController : ControllerBase
    {
        private readonly IFractionationService _fractionationService;

        public FractionationController(IFractionationService fractionationService)
        {
            _fractionationService = fractionationService;
        }

        // GET: api/Fractionation
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Fractionation>>> GetFractionations()
        {
            var fractionations = await _fractionationService.GetAllFractionationsAsync();
            return Ok(fractionations);
        }

        // GET: api/Fractionation/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Fractionation>> GetFractionation(int id)
        {
            var fractionation = await _fractionationService.GetFractionationByIdAsync(id);
            if (fractionation == null)
            {
                return NotFound();
            }

            return Ok(fractionation);
        }

        // POST: api/Fractionation
        [HttpPost]
        public async Task<ActionResult<Fractionation>> CreateFractionation(FractionationCreateDto fractionationCreateDto)
        {
            if (fractionationCreateDto == null)
            {
                return BadRequest("Fractionation data is invalid.");
            }

            var createdFractionation = await _fractionationService.CreateFractionationAsync(fractionationCreateDto);
            return CreatedAtAction(nameof(GetFractionation), new { id = createdFractionation.Id }, createdFractionation);
        }

        // PUT: api/Fractionation/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFractionation(int id, Fractionation fractionation)
        {
            if (id != fractionation.Id)
            {
                return BadRequest("Fractionation ID mismatch.");
            }

            var success = await _fractionationService.UpdateFractionationAsync(id, fractionation);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/Fractionation/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFractionation(int id)
        {
            var success = await _fractionationService.DeleteFractionationAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
