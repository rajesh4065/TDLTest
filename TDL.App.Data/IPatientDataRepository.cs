using System.Threading.Tasks;
using TDL.Common;

namespace TDL.App.Data
{

    public interface IPatientDataRepository
    {
        Task<PatientDetailsDto> GetPatientDetails();
        Task<PatientOutPutDto> UpdatePatientDetails(PatientInputDto patientInputDto);
    }
}


