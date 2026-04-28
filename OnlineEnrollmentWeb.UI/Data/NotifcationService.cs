using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class NotificationService
{
    private readonly HttpClient _http;
    public NotificationService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<string>> SendAsync(SendNotificationRequest req)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/notification", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<List<NotificationModel>>> GetByStudentAsync(int studentId)
    {
        try
        {
            var result = await _http.GetFromJsonAsync<ServiceResponse<List<NotificationModel>>>($"api/notification/{studentId}");
            return result ?? new ServiceResponse<List<NotificationModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<NotificationModel>> { Status = 500, Message = ex.Message };
        }
    }
}