using AMAP_FARM.DTO;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AMAP_FARM.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SubscribeOfferController : ControllerBase
    {
        private readonly ISubscribeOfferService _subscribeOfferService;

        public SubscribeOfferController(ISubscribeOfferService subscribeOfferService)
        {
            _subscribeOfferService = subscribeOfferService;
        }

        // POST: api/subscribeoffer
        [HttpPost]
        public async Task<ActionResult<SubscribeOfferDto>> CreateSubscribeOffer([FromBody] SubscribeOfferCreateDto subscribeOfferCreateDto)
        {
            var createdSubscribeOfferDto = await _subscribeOfferService.CreateSubscribeOfferAsync(subscribeOfferCreateDto);
            return CreatedAtAction(nameof(GetSubscribeOffer), new { id = createdSubscribeOfferDto.Id }, createdSubscribeOfferDto);
        }

        // GET: api/subscribeoffer/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<SubscribeOfferDto>> GetSubscribeOffer(int id)
        {
            var subscribeOfferDto = await _subscribeOfferService.GetSubscribeOfferByIdAsync(id);
            if (subscribeOfferDto == null)
            {
                return NotFound();
            }
            return subscribeOfferDto;
        }

        // GET: api/subscribeoffer
        [HttpGet]
        public async Task<ActionResult<List<SubscribeOfferDto>>> GetAllSubscribeOffers()
        {
            var subscribeOffers = await _subscribeOfferService.GetAllSubscribeOffersAsync();
            return Ok(subscribeOffers);
        }

        // PUT: api/subscribeoffer/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<SubscribeOfferDto>> UpdateSubscribeOffer(int id, [FromBody] SubscribeOfferCreateDto subscribeOfferCreateDto)
        {
            var updatedSubscribeOffer = await _subscribeOfferService.UpdateSubscribeOfferAsync(id, subscribeOfferCreateDto);
            if (updatedSubscribeOffer == null)
            {
                return NotFound();
            }
            return Ok(updatedSubscribeOffer);
        }

        // DELETE: api/subscribeoffer/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSubscribeOffer(int id)
        {
            var result = await _subscribeOfferService.DeleteSubscribeOfferAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
