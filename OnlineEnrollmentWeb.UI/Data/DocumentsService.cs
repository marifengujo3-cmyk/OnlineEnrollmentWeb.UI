using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class DocumentsService
{
    private readonly HttpClient _http;
    public DocumentsService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<DocumentModel>>> GetAllDocumentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<DocumentModel>>>("api/studentdocument/AllDocuments")
                   ?? new ServiceResponse<List<DocumentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<List<DocumentModel>>> GetByStudentAsync(int studentId)
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<DocumentModel>>>($"api/student/documents/{studentId}")
                   ?? new ServiceResponse<List<DocumentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<DocumentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> ApproveDocumentAsync(DocumentModel doc)
    {
        try
        {
            var response = await _http.PostAsJsonAsync("api/student/documents", doc);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }
}