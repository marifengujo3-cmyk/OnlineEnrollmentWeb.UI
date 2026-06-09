using OnlineEnrollmentWeb.UI.Model;
using OnlineEnrollmentWeb.UI.Model.Response;
using System.Net.Http.Json;

namespace OnlineEnrollmentWeb.UI.Data
{
    public class EligibilityService
    {
        private readonly HttpClient _http;
        public EligibilityService(HttpClient http) => _http = http;

        public async Task<ServiceResponse<List<RegistrarEligibilityModel>>> GetStudentsForRegistrarAsync(string schoolYear, string semester)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<ServiceResponse<List<RegistrarEligibilityModel>>>(
                    $"api/Eligibility/students?schoolYear={schoolYear}&semester={semester}");

                return response ?? new ServiceResponse<List<RegistrarEligibilityModel>>
                {
                    Status = 404,
                    Message = "No data found"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<List<RegistrarEligibilityModel>>
                {
                    Status = 500,
                    Message = ex.Message
                };
            }
        }

        // Save eligibility for a student
        public async Task<ServiceResponse<bool>> SaveRegistrarEligibilityAsync(RegistrarEligibilityModel eligibility)
        {
            try
            {
                var response = await _http.PostAsJsonAsync("api/Eligibility/save-eligibility", eligibility);
                var result = await response.Content.ReadFromJsonAsync<ServiceResponse<bool>>();

                return result ?? new ServiceResponse<bool>
                {
                    Status = 500,
                    Message = "Empty response"
                };
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>
                {
                    Status = 500,
                    Message = ex.Message
                };
            }
        }
    }
}
