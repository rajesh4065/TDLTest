using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using TDL.Common;

namespace TDL.API.Repository
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ILogger<PatientRepository> _logger;

        public PatientRepository(ILogger<PatientRepository> logger)
        {
            _logger = logger;
        }

        public async Task<PatientDetailsDto> GetPatientDetails()
        {
            try
            {
                var dataString = await File.ReadAllTextAsync("..\\Data.json");

                return JsonConvert.DeserializeObject<PatientDetailsDto>(dataString);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetPatientDetails)}:{ex.Message}");
                throw;
            }
        }

        public async Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto)
        {
            try
            {
                var dataString = await File.ReadAllTextAsync("..\\Data.json");
                var patientRecord = JsonConvert.DeserializeObject<PatientDetailsDto>(dataString);
                if (patientRecord != null && patientRecord.RecordId == patientInputDto.RecordId)
                {
                    var patientOutPutDto = new PatientOutPutDto
                    {
                        LastUpdateDateTime = DateTime.Now,
                        AuthorisedBy = patientInputDto.AuthorisedBy,
                        Conclusion = patientInputDto.Conclusion
                    };

                    return patientOutPutDto;
                }

                return null;
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(this.GetPatientDetails)}:{ex.Message}");
                throw;
            }
        }
    }
}
