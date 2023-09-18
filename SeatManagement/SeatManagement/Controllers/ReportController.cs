using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ReportDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReport _openRoomReportService;
        public ReportController(IReport _openRoomReportService)
        {
            this._openRoomReportService = _openRoomReportService;
        }

        [HttpPut]
        public IActionResult GetOpenRoomSeatView(FilterConditionsDto filters)
        {
            try
            {
                return Ok(_openRoomReportService.GetView(filters));
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }
    }
}
