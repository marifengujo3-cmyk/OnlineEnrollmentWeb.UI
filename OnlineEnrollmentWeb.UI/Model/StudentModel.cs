namespace OnlineEnrollmentWeb.UI.Model;

public class StudentModel
{
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string MiddleName { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public DateTime BirthDate { get; set; }
    public string ContactNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string StudentType { get; set; } = string.Empty;  // New / Old
    public string Status { get; set; } = string.Empty;       // Pending / Approved / Rejected
    public DateTime DateCreated { get; set; }

    // Computed helper
    public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
}

public class CreateStudentRequest
{
    public string StudentID { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;  // StudentNumber
    public string Password { get; set; } = string.Empty;
}