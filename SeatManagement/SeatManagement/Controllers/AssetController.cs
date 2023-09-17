using BuisnessLayer.Exceptions;
using BuisnessLayer.Interfaces;
using BuisnessLayer.Services;
using DataAccessLayer.Dto.ServiceDto;
using Microsoft.AspNetCore.Mvc;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AssetController : Controller
    {
        private readonly IService<AssetDto> _assetService;
        public AssetController(IService<AssetDto> _assetService)
        {
            this._assetService = _assetService;
        }

        [HttpGet]
        public IActionResult ViewAssetMappings()
        {
            try
            {
                return  Ok(_assetService.GetAllItems());
            }
            catch (Exception) 
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }
        [HttpGet("{id:int}")]
        public IActionResult GetAssetMappingById(int id)
        {
            try
            {
                var asset = _assetService.GetItemById(id);
                return Ok(asset);
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving file");
            }
        }

        [HttpPost]
        public IActionResult AddAsset(AssetDto assetDto)
        {
            try
            {
                if (assetDto == null)
                    return BadRequest();

                _assetService.AddItem(assetDto);
                return Ok("asset mapped successfully");
            }
            catch (ExceptionWhileAdding ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while adding Building");
            }
        }
    }
}
