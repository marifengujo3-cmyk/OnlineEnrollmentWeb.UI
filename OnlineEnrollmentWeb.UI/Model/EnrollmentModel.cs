namespace OnlineEnrollmentWeb.UI.Model
{
    public class EnrollmentModel
    {
        public int EnrollmentID { get; set; }
        public int StudentID { get; set; }
        public string Course { get; set; } = string.Empty;
        public string SchoolYear { get; set; } = string.Empty;
        public string Semester { get; set; } = string.Empty;
        // Pending / Approved / Rejected / Complete
        public string EnrollmentStatus { get; set; } = string.Empty;
    }
}