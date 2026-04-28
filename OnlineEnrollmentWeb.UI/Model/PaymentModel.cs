namespace OnlineEnrollmentWeb.UI.Model;

public class PaymentModel
{
    public int PaymentID { get; set; }
    public int EnrollmentID { get; set; }
    public decimal Amount { get; set; }
    // Pending / Approved / Rejected
    public string PaymentStatus { get; set; } = string.Empty;
    public DateTime PaymentDate { get; set; }
}