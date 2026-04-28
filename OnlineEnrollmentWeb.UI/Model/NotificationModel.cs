namespace OnlineEnrollmentWeb.UI.Model;

public class NotificationModel
{
    public int NotificationID { get; set; }
    public int StudentID { get; set; }
    public string Message { get; set; } = string.Empty;
    public bool IsRead { get; set; }
    public DateTime CreatedDate { get; set; }
}

public class SendNotificationRequest
{
    public int StudentID { get; set; }
    public string Message { get; set; } = string.Empty;
}
