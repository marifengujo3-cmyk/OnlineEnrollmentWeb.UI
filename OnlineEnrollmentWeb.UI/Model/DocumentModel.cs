using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Model;

public class DocumentModel
{
    public int DocumentID { get; set; }
    public int StudentID { get; set; }
    public string DocumentType { get; set; } = "";
    public string FilePath { get; set; } = "";
    public bool IsApproved { get; set; }
    public DateTime UploadedDate { get; set; }
    public string Status { get; set; } = ""; 
   
    public string StudentNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";

 
    public string Course { get; set; } = "";
    public string YearLevel { get; set; } = "";
    public string SchoolYear { get; set; } = "";
    public string Semester { get; set; } = "";
}

public class StudentDocumentSummary
{
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";
    public int DocumentCount { get; set; }
}