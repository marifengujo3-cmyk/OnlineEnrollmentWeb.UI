using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class PaymentService
{
    private readonly HttpClient _http;

    public PaymentService(HttpClient http)
    {
        _http = http;
    }
    // GET pending payments (for cashier approval)
    public async Task<ServiceResponse<List<PaymentModel>>> GetPendingPaymentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Payment/pending";
            if (!string.IsNullOrEmpty(searchTerm))
                url += $"?search={Uri.EscapeDataString(searchTerm)}";

            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PaymentModel>>>(url);
            return response ?? new ServiceResponse<List<PaymentModel>> { Status = 404, Message = "No data found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaymentModel>> { Status = 500, Message = ex.Message };
        }
    }

    // GET approved payments (for viewing history)
    public async Task<ServiceResponse<List<PaymentModel>>> GetApprovedPaymentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Payment/approved";
            if (!string.IsNullOrEmpty(searchTerm))
                url += $"?search={Uri.EscapeDataString(searchTerm)}";

            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PaymentModel>>>(url);
            return response ?? new ServiceResponse<List<PaymentModel>> { Status = 404, Message = "No data found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaymentModel>> { Status = 500, Message = ex.Message };
        }
    }

    // GET all payments (with filter by status)
    public async Task<ServiceResponse<List<PaymentModel>>> GetAllPaymentsAsync(string searchTerm = null)
    {
        try
        {
            var url = "api/Payment/all";
            if (!string.IsNullOrEmpty(searchTerm))
                url += $"?search={Uri.EscapeDataString(searchTerm)}";

            var response = await _http.GetFromJsonAsync<ServiceResponse<List<PaymentModel>>>(url);
            return response ?? new ServiceResponse<List<PaymentModel>> { Status = 404, Message = "No data found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaymentModel>> { Status = 500, Message = ex.Message };
        }
    }

    // POST approve payment
    public async Task<ServiceResponse<PaymentModel>> ApprovePaymentAsync(int paymentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Payment/approve/{paymentId}", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<PaymentModel>>();
            return result ?? new ServiceResponse<PaymentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<PaymentModel> { Status = 500, Message = ex.Message };
        }
    }

    // POST reject payment
    public async Task<ServiceResponse<PaymentModel>> RejectPaymentAsync(int paymentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/Payment/reject/{paymentId}", null);
            var result = await response.Content.ReadFromJsonAsync<ServiceResponse<PaymentModel>>();
            return result ?? new ServiceResponse<PaymentModel> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<PaymentModel> { Status = 500, Message = ex.Message };
        }
    }
}