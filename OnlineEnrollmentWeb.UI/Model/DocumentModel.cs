namespace OnlineEnrollmentWeb.UI.Model;

public class DocumentModel
{
    public int DocumentID { get; set; }
    public int StudentID { get; set; }
    public string DocumentType { get; set; } = string.Empty;
    public string FilePath { get; set; } = string.Empty;
    public bool IsApproved { get; set; }
    public DateTime UploadedDate { get; set; }
}
