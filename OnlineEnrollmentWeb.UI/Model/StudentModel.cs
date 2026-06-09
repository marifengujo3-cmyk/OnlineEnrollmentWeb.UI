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
    public string StudentType { get; set; } = string.Empty; 

    public string Status { get; set; } = string.Empty;     
    public DateTime DateCreated { get; set; }

    public string FullName => $"{FirstName} {MiddleName} {LastName}".Trim();
}

public class CreateStudentRequest
{
    public string StudentID { get; set; } = string.Empty;
    public string Username { get; set; } = string.Empty;  
    public string Password { get; set; } = string.Empty;
}

public class StudentDetailsModel
{
    // Student Info
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string MiddleName { get; set; } = "";
    public string FullName => $"{LastName}, {FirstName} {MiddleName}".Trim();
    public string Email { get; set; } = "";
    public string ContactNumber { get; set; } = "";

    public string StudentType { get; set; } = "";
    public string StudentStatus { get; set; } = "";

    public string Course { get; set; } = "";
    public string YearLevel { get; set; } = "";
    public string Semester { get; set; } = "";
    public string SchoolYear { get; set; } = "";
    public string EnrollmentStatus { get; set; } = "";


    public string DocumentStatus { get; set; } = "";


    public string PaymentStatus { get; set; } = "";

    
    public string OverallStatus { get; set; } = "";

 
    public int TotalCount { get; set; }
}

public class StudentsWithStatusResponse
{
    public List<StudentDetailsModel> Students { get; set; } = new();
    public int TotalCount { get; set; }
    public int CurrentPage { get; set; }
    public int PageSize { get; set; }
    public int TotalPages { get; set; }
}
public class RegistrarEligibilityModel
{
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = "";
    public string FullName { get; set; } = "";
    public string Course { get; set; } = "";
    public int YearLevel { get; set; }
    public string Semester { get; set; } = "";
    public string SchoolYear { get; set; } = "";
    public bool IsGradeCleared { get; set; }
    public bool IsClearanceCleared { get; set; }
    public bool IsPaymentCleared { get; set; }
    public string? GradeMessage { get; set; }
    public string? ClearanceMessage { get; set; }
    public string? PaymentMessage { get; set; }
}

public class StudentEligibilityModel
{
    public bool IsEligible { get; set; }
    public string Message { get; set; } = "";
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = "";
    public string FullName { get; set; } = "";
    public bool HasLockGrades { get; set; }
    public bool HasLockClearance { get; set; }
    public bool HasLockPayment { get; set; }
    public decimal OutstandingBalance { get; set; }
    public int FailingGradesCount { get; set; }
    public int PendingDocumentsCount { get; set; }
}