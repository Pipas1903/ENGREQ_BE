using AMAP_FARM.DTO;
using AMAP_FARM.Models;
using AMAP_FARM.Services;
using Microsoft.AspNetCore.Mvc;

namespace AMAP_FARM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentMethodController : ControllerBase
    {
        private readonly IPaymentMethodService _paymentMethodService;

        public PaymentMethodController(IPaymentMethodService paymentMethodService)
        {
            _paymentMethodService = paymentMethodService;
        }

        // GET: api/PaymentMethod
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PaymentMethod>>> GetPaymentMethods()
        {
            var paymentMethods = await _paymentMethodService.GetAllPaymentMethodsAsync();
            return Ok(paymentMethods);
        }

        // GET: api/PaymentMethod/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PaymentMethod>> GetPaymentMethod(int id)
        {
            var paymentMethod = await _paymentMethodService.GetPaymentMethodByIdAsync(id);
            if (paymentMethod == null)
            {
                return NotFound();
            }

            return Ok(paymentMethod);
        }

        // POST: api/PaymentMethod
        [HttpPost]
        public async Task<ActionResult<PaymentMethod>> CreatePaymentMethod(PaymentMethodCreateDto paymentMethodCreateDto)
        {
            if (paymentMethodCreateDto == null)
            {
                return BadRequest("PaymentMethod data is invalid.");
            }

            var createdPaymentMethod = await _paymentMethodService.CreatePaymentMethodAsync(paymentMethodCreateDto);
            return CreatedAtAction(nameof(GetPaymentMethod), new { id = createdPaymentMethod.Id }, createdPaymentMethod);
        }

        // PUT: api/PaymentMethod/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePaymentMethod(int id, PaymentMethod paymentMethod)
        {
            if (id != paymentMethod.Id)
            {
                return BadRequest("PaymentMethod ID mismatch.");
            }

            var success = await _paymentMethodService.UpdatePaymentMethodAsync(id, paymentMethod);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }

        // DELETE: api/PaymentMethod/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentMethod(int id)
        {
            var success = await _paymentMethodService.DeletePaymentMethodAsync(id);
            if (!success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
