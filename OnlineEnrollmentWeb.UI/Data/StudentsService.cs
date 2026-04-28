using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class StudentsService
{
    private readonly HttpClient _http;
    public StudentsService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<StudentModel>>> GetAllStudentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<StudentModel>>>("api/student/AllStudents")
                   ?? new ServiceResponse<List<StudentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<StudentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<StudentModel>> GetStudentByIdAsync(int studentId)
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<StudentModel>>($"api/student/{studentId}")
                   ?? new ServiceResponse<StudentModel> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<StudentModel>> UpdateStudentAsync(StudentModel student)
    {
        try
        {
            var response = await _http.PutAsJsonAsync("api/student", student);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>()
                   ?? new ServiceResponse<StudentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel> { Status = 500, Message = ex.Message };
        }
    }
}