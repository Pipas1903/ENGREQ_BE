
public interface ISubscriptionPeriodService
{
    Task<List<SubscriptionPeriod>> GetAllSubscriptionPeriodsAsync();
    Task<SubscriptionPeriod> CreateSubscriptionPeriodAsync(SubscriptionPeriod subscriptionPeriod, List<DateTime> deliveryDates);

    Task<List<DeliveryDate>> GetDeliveryDatesBySubscriptionIdAsync(int subscriptionId);
}
