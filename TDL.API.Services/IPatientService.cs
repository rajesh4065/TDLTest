using System.Threading.Tasks;
using TDL.Common;

namespace TDL.API.Services
{
    public interface IPatientService
    {
        Task<PatientDetailsDto> GetPatientDetails();

        Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto);
    }
}
