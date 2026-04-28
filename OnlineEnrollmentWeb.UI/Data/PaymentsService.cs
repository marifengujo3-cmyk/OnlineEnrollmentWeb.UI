using System.Net.Http.Json;
using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;

namespace OnlineEnrollmentWeb.UI.Data;

public class PaymentsService
{
    private readonly HttpClient _http;
    public PaymentsService(HttpClient http) => _http = http;

    public async Task<ServiceResponse<List<PaymentModel>>> GetAllPaymentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<PaymentModel>>>("api/payment")
                   ?? new ServiceResponse<List<PaymentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaymentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<List<PaymentModel>>> GetPendingPaymentsAsync()
    {
        try
        {
            return await _http.GetFromJsonAsync<ServiceResponse<List<PaymentModel>>>("api/payment/pending")
                   ?? new ServiceResponse<List<PaymentModel>> { Status = 404, Message = "Not found" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<List<PaymentModel>> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> ApprovePaymentAsync(int paymentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/payment/{paymentId}/approve", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }

    public async Task<ServiceResponse<string>> RejectPaymentAsync(int paymentId)
    {
        try
        {
            var response = await _http.PostAsync($"api/payment/{paymentId}/reject", null);
            return await response.Content.ReadFromJsonAsync<ServiceResponse<string>>()
                   ?? new ServiceResponse<string> { Status = 500, Message = "Empty response" };
        }
        catch (Exception ex)
        {
            return new ServiceResponse<string> { Status = 500, Message = ex.Message };
        }
    }
}