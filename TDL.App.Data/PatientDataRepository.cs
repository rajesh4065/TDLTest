using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TDL.Common;

namespace TDL.App.Data
{
    public class PatientDataRepository : IPatientDataRepository
    {
        private readonly ILogger<PatientDataRepository> _logger;

        private readonly HttpClient _httpClient;
        public PatientDataRepository(ILogger<PatientDataRepository> logger, HttpClient httpClient)
        {
            this._logger = logger;

            this._httpClient = httpClient;
        }

        public async Task<PatientDetailsDto> GetPatientDetails()
        {
            try
            {
                var result = new PatientDetailsDto();
                var response = await this._httpClient.GetAsync("https://localhost:44378/api/Patient/GetPatientDetails");
                if (response.IsSuccessStatusCode)
                {
                    result = JsonConvert.DeserializeObject<PatientDetailsDto>(
                        await response.Content.ReadAsStringAsync());
                }

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetPatientDetails)}: {ex.Message}");
                throw;
            }
        }
     
        public async Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto)
        {
            try
            {
                var result = new PatientOutPutDto();

                var content = new StringContent(JsonConvert.SerializeObject(patientInputDto), Encoding.UTF8, "application/json");
                var response = await this._httpClient.PutAsync("https://localhost:44378/api/Patient/UpdatePatientDetails", content);

                if (response.IsSuccessStatusCode)
                {
                    
                    result = JsonConvert.DeserializeObject<PatientOutPutDto>(await response.Content.ReadAsStringAsync());
                    result.Status = true;
                }
                else
                {
                    result.Status = false;
                }

                return result;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.UpdatePatientDetails)}: {ex.Message}");
                throw;
            }
        }
    }
}
