using System.Threading.Tasks;
using TDL.App.Data;
using TDL.Common;

namespace TDL.App.Services
{
    public class PatientAppService : IPatientAppService
    {
        private readonly IPatientDataRepository _iPatientDataRepository;
        public PatientAppService(IPatientDataRepository iPatientDataRepository)
        {
            _iPatientDataRepository = iPatientDataRepository;
        }
        public async Task<PatientDetailsDto> GetPatientDetails()
        {

            var data = await _iPatientDataRepository.GetPatientDetails();
            data.PatientSubmitDto.RecordId = data.RecordId;
            return data;
        }

        public async Task<PatientOutPutDto> UpdatePatientDetails(PatientSubmitDto patientInputDto)
        {
            var patient = new PatientInputDto
            {
                AuthorisedBy = patientInputDto.AuthorisedBy,
                Conclusion = patientInputDto.Conclusion,
                RecordId = patientInputDto.RecordId
            };
            return await _iPatientDataRepository.UpdatePatientDetails(patient);
        }
    }
}
