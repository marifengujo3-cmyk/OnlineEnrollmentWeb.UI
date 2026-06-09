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
            var response = await _http.GetAsync("api/Enrollment/all");
            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<EnrollmentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<EnrollmentModel>()
                };
            }
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>();
            return result ?? new ServiceResponse<List<EnrollmentModel>> { Status = 404, Message = "Not found" };
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
            var response = await _http.GetAsync("api/Enrollment/pending");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<EnrollmentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<EnrollmentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>();
            return result ?? new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<string>> ApproveEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Enrollment/{enrollmentId}/approve", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            return result ?? new ServiceResponse<string>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<string>> RejectEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Enrollment/{enrollmentId}/reject", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<string>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<string>>();
            return result ?? new ServiceResponse<string>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<EnrollmentModel>>> GetAdminPendingEnrollmentsAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Enrollment/admin-pending");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<EnrollmentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<EnrollmentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>();
            return result ?? new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<EnrollmentModel>>> GetApprovedEnrollmentsAsync()
    {
        try
        {
            var response = await _http.GetAsync("api/Enrollment/approved");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<EnrollmentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<EnrollmentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<EnrollmentModel>>>();
            return result ?? new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<EnrollmentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<EnrollmentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<EnrollmentModel>> AdminApproveEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Enrollment/admin-approve/{enrollmentId}", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<EnrollmentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<EnrollmentModel>>();
            return result ?? new ServiceResponse<EnrollmentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<EnrollmentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<EnrollmentModel>> AdminRejectEnrollmentAsync(int enrollmentId)
    {
        try
        {
            Console.WriteLine($"EnrollmentService: Rejecting enrollment {enrollmentId}");
            var response = await _http.PostAsync($"api/Enrollment/admin-reject/{enrollmentId}", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<EnrollmentModel>>();
            Console.WriteLine($"EnrollmentService: Response status {result?.Status}");
            return result ?? new ServiceResponse<EnrollmentModel> { Status = 500, Message = "Empty response", Success = false };
        }
        catch (Exception ex)
        {
            Console.WriteLine($"EnrollmentService: Error {ex.Message}");
            return new ServiceResponse<EnrollmentModel> { Status = 500, Message = ex.Message, Success = false };
        }
    }
    public async Task<ServiceResponse<EnrollmentModel>> CompleteEnrollmentAsync(int enrollmentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Enrollment/{enrollmentId}/complete", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<EnrollmentModel>>();
            return result ?? new ServiceResponse<EnrollmentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<EnrollmentModel> { Status = 500, Message = ex.Message };
        }
    }
}