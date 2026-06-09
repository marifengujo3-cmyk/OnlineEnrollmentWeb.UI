namespace OnlineEnrollmentWeb.UI.Model;

public class LoginModel
{
    public string Username { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class UserInfo
{
    public int UserID { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;  
    public string Token { get; set; } = string.Empty;
}
public class StudentAccountListModel
{
    public int LoginID { get; set; }
    public int StudentID { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
    public string StudentNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = "";
    public string StudentStatus { get; set; } = "";
}

public class StudentAccountModel
{
    public int StudentID { get; set; }
    public string StudentNumber { get; set; } = "";
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
    public string FullName => $"{FirstName} {LastName}";
    public string Email { get; set; } = "";
    public string ContactNumber { get; set; } = "";
    public string Status { get; set; } = "";
}



public class CreateAccountResponse
{
    public bool Success { get; set; }
    public string Message { get; set; } = "";
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}
public class StudentCreateModel
{
    public int StudentID { get; set; }
    public string Username { get; set; } = "";
    public string Password { get; set; } = "";
}