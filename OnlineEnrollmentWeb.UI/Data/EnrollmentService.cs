using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class EnrollmentService
{
    private readonly HttpClient _http;
    public EnrollmentService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<EnrollmentModel>>> GetAllEnrollmentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>("api/enrollment")
                   ?? new ServiceResponse<List<EnrollmentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<EnrollmentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<List<EnrollmentModel>>> GetPendingEnrollmentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>("api/enrollment/pending")
                   ?? new ServiceResponse<List<EnrollmentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<EnrollmentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> ApproveEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/enrollment/{enrollmentId}/approve", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> RejectEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/enrollment/{enrollmentId}/reject", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }
}