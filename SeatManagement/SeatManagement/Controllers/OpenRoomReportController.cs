using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto.ReportDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OpenRoomReportController : ControllerBase
    {
        private readonly IReport<OpenRoomView> _openRoomReportService;
        public OpenRoomReportController(IReport<OpenRoomView> _openRoomReportService)
        {
            this._openRoomReportService = _openRoomReportService;
        }


        [HttpGet]
        public IActionResult GetOpenRoomSeatView()
        {
            try
            {
                return Ok(_openRoomReportService.GetView());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }
    }
}
