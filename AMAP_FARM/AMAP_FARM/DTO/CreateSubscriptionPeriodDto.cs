public class CreateSubscriptionPeriodDto
{
    public string Name { get; set; }
    public string Duration { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public bool AreNotificationsSent { get; set; }
    public List<DateTime> DeliveryDates { get; set; }
}
