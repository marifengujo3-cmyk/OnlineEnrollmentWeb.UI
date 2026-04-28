using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class GradesService
{
    private readonly HttpClient _http;
    public GradesService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<GradesModel>>> GetGradesByStudentAsync(int studentId)
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<GradesModel>>>($"api/grades/student/{studentId}")
                   ?? new ServiceResponse<List<GradesModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<GradesModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> AddGradeAsync(AddGradeRequest req)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/grades", req);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> UpdateGradeAsync(int gradeId, GradesModel grade)
    {
        try
        {
            var response = await _http.PutAsJsonAsync($"api/grades/{gradeId}", grade);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }
}