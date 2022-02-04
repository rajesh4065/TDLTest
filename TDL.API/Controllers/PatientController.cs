using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TDL.API.Services;
using TDL.Common;

namespace TDL.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _iPatientService;

        private readonly ILogger<PatientController> _logger;

        public PatientController(ILogger<PatientController> logger, IPatientService iPatientService)
        {
            _logger = logger;
            _iPatientService = iPatientService;
        }

        [HttpGet("GetPatientDetails")]
        public async Task<IActionResult> Get()
        {
            try
            {
                this._logger.LogDebug($"Called Method: {nameof(PatientController)}/{nameof(this.Get)}");
                var result = await _iPatientService.GetPatientDetails();
                return this.Ok(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(PatientController)}/{nameof(this.Get)}: {ex.Message}");
                return StatusCode(500);
            }
        }
        [HttpPut("UpdatePatientDetails")]
        public async Task<IActionResult> UpdatePatientDetails([FromBody] PatientInputDto patientInputDto)
        {
            try
            {
                this._logger.LogDebug($"Called Method: {nameof(PatientController)}/{nameof(this.UpdatePatientDetails)}");
                var result = await _iPatientService.UpdatePatientDetails(patientInputDto);
                if (result != null)
                {
                    return this.Ok(result);
                }
                return this.NotFound();
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(PatientController)}/{nameof(this.UpdatePatientDetails)}: {ex.Message}");
                return StatusCode(500);
            }
        }
    }
}
