using System.Net.Http.Json;
using Blazored.LocalStorage;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class AuthService
{
    private readonly HttpClient _http;
    private readonly ILocalStorageService _localStorage;

    public AuthService(HttpClient http, ILocalStorageService localStorage)
    {
        _http = http;
        _localStorage = localStorage;
    }

    public async Task<ServiceResponse<UserInfo>> LoginAsync(LoginModel login)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/login", login);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<UserInfo>>();

            if (result != null && result.Status == 200 && result.Data != null)
            {
                await _localStorage.SetItemAsync("userInfo", result.Data);
                await _localStorage.SetItemAsync("authToken", result.Token);
            }

            return result ?? new ServiceResponse<UserInfo>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<UserInfo>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentAccountModel>> GetStudentByIdAsync(int studentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/auth/student/{studentId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentAccountModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentAccountModel>>();
            return result ?? new ServiceResponse<StudentAccountModel>
            {
                Status = 404,
                Message = "Not found",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentAccountModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<StudentAccountListModel>>> GetAllStudentAccountsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/auth/all-accounts";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                url += $"?search={Uri.EscapeDataString(searchTerm)}";
            }

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<StudentAccountListModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<StudentAccountListModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<StudentAccountListModel>>>();
            return result ?? new ServiceResponse<List<StudentAccountListModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<StudentAccountListModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<StudentAccountListModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<StudentAccountListModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<CreateAccountResponse>> CreateAccountAsync(int studentId, string username, string password)
    {
        try
        {
            var request = new StudentCreateModel
            {
                StudentID = studentId,
                Username = username,
                Password = password
            };

            var response = await _http.PostAsJsonAsync("api/auth/create-student", request);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<CreateAccountResponse>>();

            return result ?? new ServiceResponse<CreateAccountResponse>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<CreateAccountResponse>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<bool>> AccountExistsAsync(int studentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/auth/account-exists/{studentId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<bool>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = false,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();
            return result ?? new ServiceResponse<bool>
            {
                Status = 404,
                Data = false,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<bool>
            {
                Status = 500,
                Message = ex.Message,
                Data = false,
                Success = false
            };
        }
    }

    public async Task<UserInfo?> GetCurrentUserAsync()
    {
        return await _localStorage.GetItemAsync<UserInfo>("userInfo");
    }

    public async Task LogoutAsync()
    {
        await _localStorage.RemoveItemAsync("userInfo");
        await _localStorage.RemoveItemAsync("authToken");
    }
}