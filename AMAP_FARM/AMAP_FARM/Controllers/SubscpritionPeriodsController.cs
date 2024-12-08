using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class SubscriptionPeriodsController : ControllerBase
{
    private readonly ISubscriptionPeriodService _subscriptionPeriodService;

    // Constructor injection of ISubscriptionPeriodService
    public SubscriptionPeriodsController(ISubscriptionPeriodService subscriptionPeriodService)
    {
        _subscriptionPeriodService = subscriptionPeriodService;
    }

    // GET api/subscriptionperiods
    [HttpGet]

    public async Task<ActionResult<List<SubscriptionPeriod>>> GetAllSubscriptionPeriods()
    {
        var subscriptionPeriods = await _subscriptionPeriodService.GetAllSubscriptionPeriodsAsync();
        return Ok(subscriptionPeriods);
    }

    // GET api/deliveryDates
    [HttpGet("{subscriptionId}")]

    public async Task<ActionResult<List<SubscriptionPeriod>>> GetDeliveryDatesBySubscription(int subscriptionId)
    {
        var subscriptionPeriods = await _subscriptionPeriodService.GetDeliveryDatesBySubscriptionIdAsync(subscriptionId);
        return Ok(subscriptionPeriods);
    }


    // POST api/subscriptionperiods
    [HttpPost]
    public async Task<ActionResult<SubscriptionPeriod>> CreateSubscriptionPeriod([FromBody] CreateSubscriptionPeriodDto dto)
    {
        if (dto == null)
        {
            return BadRequest("Invalid subscription period data.");
        }
        var random = new Random();

        // Convert the DTO to SubscriptionPeriod
        var subscriptionPeriod = new SubscriptionPeriod
        {
            ExternalId = random.Next(1, 1000000),
            Name = dto.Name,
            Duration = dto.Duration,
            StartDate = dto.StartDate,
            EndDate = dto.EndDate,
            AreNotificationsSent = dto.AreNotificationsSent
        };

        var deliveryDates = dto.DeliveryDates;

        // Call the service to create the SubscriptionPeriod and its DeliveryDates
        var createdSubscriptionPeriod = await _subscriptionPeriodService.CreateSubscriptionPeriodAsync(subscriptionPeriod, deliveryDates);

        return CreatedAtAction(nameof(GetAllSubscriptionPeriods), new { id = createdSubscriptionPeriod.Id }, createdSubscriptionPeriod);
    }


}
