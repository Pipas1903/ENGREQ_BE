using Microsoft.EntityFrameworkCore;

public class SubscriptionPeriodService : ISubscriptionPeriodService
{
    private readonly AppDbContext _context;

    public SubscriptionPeriodService(AppDbContext context)
    {
        _context = context;
    }

    // Retrieve all SubscriptionPeriods with DeliveryDates
    public async Task<List<SubscriptionPeriod>> GetAllSubscriptionPeriodsAsync()
    {
        return await _context.SubscriptionPeriods
                             .ToListAsync();
    }

    // Create a new SubscriptionPeriod
    public async Task<SubscriptionPeriod> CreateSubscriptionPeriodAsync(SubscriptionPeriod subscriptionPeriod, List<DateTime> deliveryDates)
    {
        // Save the SubscriptionPeriod
        _context.SubscriptionPeriods.Add(subscriptionPeriod);

        // Save all DeliveryDates for this SubscriptionPeriod
        foreach (var date in deliveryDates)
        {
            var deliveryDate = new DeliveryDate();

            deliveryDate.Date = date;
            deliveryDate.SubscriptionPeriodId = subscriptionPeriod.Id;
            _context.DeliveryDates.Add(deliveryDate);
        }

        // Save changes to the database
        await _context.SaveChangesAsync();

        return subscriptionPeriod;
    }


}
