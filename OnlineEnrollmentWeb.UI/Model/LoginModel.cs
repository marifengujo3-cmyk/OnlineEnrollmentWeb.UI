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
