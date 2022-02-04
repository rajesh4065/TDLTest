using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using TDL.App.Services;
using TDL.Common;

namespace TDL.App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IPatientAppService _iPatientAppService;


        public HomeController(ILogger<HomeController> logger, IPatientAppService iPatientAppService)
        {
            this._logger = logger;
            this._iPatientAppService = iPatientAppService;
        }

      
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var result = await this._iPatientAppService.GetPatientDetails();
                if (TempData["success"] != null)
                {
                    result.Status = true;
                    result.PatientSubmitDto.LastUpdateDateTime = Convert.ToDateTime(TempData["success"]);
                    TempData["success"] = null;
                }

                if (TempData["fail"] != null)
                {
                    result.Status = false;
                    result.PatientSubmitDto.LastUpdateDateTime = Convert.ToDateTime(TempData["fail"]);
                    TempData["fail"] = null;
                }
                return this.View(result);
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(HomeController)}/{nameof(this.Index)}: {ex.Message}");
                return this.RedirectToAction("Error", "Home");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Index(PatientSubmitDto patientInputDto)
        {
            try
            {
                var result = await this._iPatientAppService.UpdatePatientDetails(patientInputDto);
                if (result.Status)
                {
                    TempData["success"] = result.LastUpdateDateTime;
                }
                else
                {
                    TempData["fail"] = DateTime.MinValue;
                }

                return this.RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                this._logger.LogError(ex, $"Exception: {nameof(HomeController)}/{nameof(this.Index)}: {ex.Message}");
                return this.RedirectToAction("Error", "Home");
            }
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
