namespace OnlineEnrollmentWeb.UI.Model;

public class GradesModel
{
    public int GradeID { get; set; }
    public int StudentID { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SchoolYear { get; set; } = string.Empty;
    public string Semester { get; set; } = string.Empty;
    public decimal? Grade { get; set; }
    // Passed / Failed / Incomplete
    public string Remarks { get; set; } = string.Empty;
}

public class AddGradeRequest
{
    public int StudentID { get; set; }
    public string SubjectName { get; set; } = string.Empty;
    public string SchoolYear { get; set; } = string.Empty;
    public string Semester { get; set; } = string.Empty;
    public decimal? Grade { get; set; }
    public string Remarks { get; set; } = string.Empty;
}