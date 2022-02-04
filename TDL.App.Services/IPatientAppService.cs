using System.Threading.Tasks;
using TDL.Common;

namespace TDL.App.Services
{
    public interface IPatientAppService
    {
        Task<PatientDetailsDto> GetPatientDetails();

        Task<PatientOutPutDto> UpdatePatientDetails(PatientSubmitDto patientInputDto);
    }
}
