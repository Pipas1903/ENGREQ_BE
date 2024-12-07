using AMAP_FARM.DTO;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAP_FARM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OfferController(IOfferService offerService)
        {
            _offerService = offerService;
        }

        // POST: api/offer
        [HttpPost]
        public async Task<ActionResult<OfferDto>> CreateOffer([FromBody] OfferDto offerDto)
        {
            var createdOfferDto = await _offerService.CreateOfferAsync(offerDto);
            return CreatedAtAction(nameof(GetOffer), new { id = createdOfferDto.Id }, createdOfferDto);
        }

        // GET: api/offer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<OfferDto>> GetOffer(int id)
        {
            var offerDto = await _offerService.GetOfferByIdAsync(id);
            if (offerDto == null)
            {
                return NotFound();
            }
            return offerDto;
        }

        // GET: api/offer
        [HttpGet]
        public async Task<ActionResult<List<OfferDto>>> GetAllOffers()
        {
            var offers = await _offerService.GetAllOffersAsync();
            return Ok(offers);
        }

        // PUT: api/offer/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<OfferDto>> UpdateOffer(int id, [FromBody] OfferDto offerDto)
        {
            var updatedOffer = await _offerService.UpdateOfferAsync(id, offerDto);
            if (updatedOffer == null)
            {
                return NotFound();
            }
            return Ok(updatedOffer);
        }

        // DELETE: api/offer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOffer(int id)
        {
            var result = await _offerService.DeleteOfferAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}

