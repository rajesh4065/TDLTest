using System.Threading.Tasks;
using TDL.Common;

namespace TDL.API.Repository
{

    public interface IPatientRepository
    {
        Task<PatientDetailsDto> GetPatientDetails();
        Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto);
    }
}


