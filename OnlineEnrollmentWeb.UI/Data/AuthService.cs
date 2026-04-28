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
            if (result?.Status == 200 && result.Data != null)
                await _localStorage.SetItemAsync("userInfo", result.Data);

            return result ?? new ServiceResponse<UserInfo> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<UserInfo> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> CreateStudentAccountAsync(CreateStudentRequest req)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/auth/create-student", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<UserInfo?> GetCurrentUserAsync()
        => await _localStorage.GetItemAsync<UserInfo>("userInfo");

    public async Task LogoutAsync()
        => await _localStorage.RemoveItemAsync("userInfo");
}