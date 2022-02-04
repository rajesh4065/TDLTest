

using System.Threading.Tasks;
using TDL.API.Repository;
using TDL.Common;

namespace TDL.API.Services
{
    public class PatientService : IPatientService
    {
        private readonly IPatientRepository _iPatientRepository;
        public PatientService(IPatientRepository iPatientRepository)
        {
            _iPatientRepository = iPatientRepository;
        }
        public async Task<PatientDetailsDto> GetPatientDetails()
        {
            return await _iPatientRepository.GetPatientDetails();
        }

        public async Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto)
        {
            return await _iPatientRepository.UpdatePatientDetails(patientInputDto);
        }
    }
}
