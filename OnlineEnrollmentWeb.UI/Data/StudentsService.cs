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
            var response = await _http.GetAsync("api/Student/AllStudents");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<StudentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<StudentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<StudentModel>>>();
            return result ?? new ServiceResponse<List<StudentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<StudentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<StudentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<StudentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentModel>> GetStudentByIdAsync(int studentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/Student/{studentId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel>
            {
                Status = 404,
                Message = "Not found",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentModel>> UpdateStudentAsync(StudentModel student)
    {
        try
        {
            var response = await _http.PutAsJsonAsync("api/Student", student);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentsWithStatusResponse>> GetAllStudentsWithStatusAsync(
     string searchTerm = null,
     int pageNumber = 1,
     int pageSize = 10,
     string studentStatus = null,
     string enrollmentStatus = null,
     string paymentStatus = null,
     string documentStatus = null,
     string course = null,
     string yearLevel = null,
     string studentType = null,
     string overallStatus = null) 
    {
        try
        {
            var query = $"?pageNumber={pageNumber}&pageSize={pageSize}";

            if (!string.IsNullOrEmpty(searchTerm)) query += $"&search={Uri.EscapeDataString(searchTerm)}";
            if (!string.IsNullOrEmpty(studentStatus)) query += $"&studentStatus={studentStatus}";
            if (!string.IsNullOrEmpty(enrollmentStatus)) query += $"&enrollmentStatus={enrollmentStatus}";
            if (!string.IsNullOrEmpty(paymentStatus)) query += $"&paymentStatus={paymentStatus}";
            if (!string.IsNullOrEmpty(documentStatus)) query += $"&documentStatus={documentStatus}";
            if (!string.IsNullOrEmpty(course)) query += $"&course={Uri.EscapeDataString(course)}";
            if (!string.IsNullOrEmpty(yearLevel)) query += $"&yearLevel={yearLevel}";
            if (!string.IsNullOrEmpty(studentType)) query += $"&studentType={studentType}";
            if (!string.IsNullOrEmpty(overallStatus)) query += $"&overallStatus={overallStatus}";  // Add this line

            var url = $"api/StudentDetails/students-with-status{query}";
            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentsWithStatusResponse>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentsWithStatusResponse>>();
            return result ?? new ServiceResponse<StudentsWithStatusResponse>
            {
                Status = 404,
                Message = "Not found",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentsWithStatusResponse>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentModel>> ApproveStudentAsync(int id)
    {
        try
        {
            var response = await _http.PostAsync($"api/StudentDetails/approve/{id}", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<StudentModel>> RejectStudentAsync(int studentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/StudentDetails/reject/{studentId}", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<StudentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<StudentModel>>();
            return result ?? new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<StudentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }
   
}