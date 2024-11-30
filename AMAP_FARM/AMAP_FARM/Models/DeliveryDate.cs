public class DeliveryDate
{
    public int Id { get; set; } // Primary Key
    public int SubscriptionPeriodId { get; set; } // Foreign Key to SubscriptionPeriod
    public DateTime Date { get; set; } // Date for the delivery
}
