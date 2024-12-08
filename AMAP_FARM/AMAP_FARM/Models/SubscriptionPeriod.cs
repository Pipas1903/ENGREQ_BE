public class SubscriptionPeriod
{
    public int Id { get; set; } // Primary Key
    public int ExternalId { get; set; } 
    public string Name { get; set; } // Name of the period
    public string Duration { get; set; } // Duration type (e.g., Semestral, Quarterly)
    public DateTime StartDate { get; set; } // Start Date
    public DateTime EndDate { get; set; } // End Date
    public bool AreNotificationsSent { get; set; } = false; // Notification flag

    // Navigation property for related delivery dates
    // Navigation property
}

