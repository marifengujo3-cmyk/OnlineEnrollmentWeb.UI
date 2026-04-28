namespace OnlineEnrollmentWeb.UI.Model.Response;

    public class ServiceResponse<T>
    {
    public int Status { get; set; }       // 200, 400, 500
    public string Message { get; set; } = string.Empty;
    public T? Data { get; set; }

}
