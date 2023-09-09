using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto.ReportDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomReportController : ControllerBase
    {
        private readonly IReport<ReportView> _openRoomReportService;
        public OpenRoomReportController(IReport<ReportView> _openRoomReportService)
        {
            this._openRoomReportService = _openRoomReportService;
        }


        [HttpGet]
        public IActionResult GetOpenRoomSeatView(string type)
        {
            try
            {
                return Ok(_openRoomReportService.GetView(type));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }
    }
}
