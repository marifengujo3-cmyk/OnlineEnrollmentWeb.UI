using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class DocumentsService
{
    private readonly HttpClient _http;
    public DocumentsService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<DocumentModel>>> GetAllDocumentsWithStudentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Document/documents/all";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                url += $"?search={Uri.EscapeDataString(searchTerm)}";
            }

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<DocumentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<DocumentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<DocumentModel>>>();
            return result ?? new ServiceResponse<List<DocumentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<DocumentModel>>> GetPendingDocumentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Document/documents/pending";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                url += $"?search={Uri.EscapeDataString(searchTerm)}";
            }

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<DocumentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<DocumentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<DocumentModel>>>();
            return result ?? new ServiceResponse<List<DocumentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<DocumentModel>>> GetApprovedDocumentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Document/documents/approved";
            if (!string.IsNullOrEmpty(searchTerm))
            {
                url += $"?search={Uri.EscapeDataString(searchTerm)}";
            }

            var response = await _http.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<DocumentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<DocumentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<DocumentModel>>>();
            return result ?? new ServiceResponse<List<DocumentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<DocumentModel>> ApproveDocumentAsync(int id)
    {
        try
        {
            var response = await _http.PostAsync($"api/Document/documents/approve/{id}", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<DocumentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<DocumentModel>>();
            return result ?? new ServiceResponse<DocumentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<DocumentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<DocumentModel>> RejectDocumentAsync(int documentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Document/documents/reject/{documentId}", null);

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<DocumentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<DocumentModel>>();
            return result ?? new ServiceResponse<DocumentModel>
            {
                Status = 500,
                Message = "Empty response",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<DocumentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<DocumentModel>> GetDocumentByIdAsync(int documentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/Document/documents/{documentId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<DocumentModel>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = null,
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<DocumentModel>>();
            return result ?? new ServiceResponse<DocumentModel>
            {
                Status = 404,
                Message = "Not found",
                Data = null,
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<DocumentModel>
            {
                Status = 500,
                Message = ex.Message,
                Data = null,
                Success = false
            };
        }
    }

    public async Task<ServiceResponse<List<DocumentModel>>> GetDocumentsByStudentAsync(int studentId)
    {
        try
        {
            var response = await _http.GetAsync($"api/Document/documents/student/{studentId}");

            if (!response.IsSuccessStatusCode)
            {
                return new ServiceResponse<List<DocumentModel>>
                {
                    Status = (int)response.StatusCode,
                    Message = $"HTTP Error: {response.StatusCode}",
                    Data = new List<DocumentModel>(),
                    Success = false
                };
            }

            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<List<DocumentModel>>>();
            return result ?? new ServiceResponse<List<DocumentModel>>
            {
                Status = 404,
                Message = "Not found",
                Data = new List<DocumentModel>(),
                Success = false
            };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>>
            {
                Status = 500,
                Message = ex.Message,
                Data = new List<DocumentModel>(),
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
}