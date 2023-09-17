using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<EmployeeDto> _employeeService;

        public EmployeeController(IService<EmployeeDto> employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetAllItems();
                return Ok(employees);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving employees");
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeService.GetItemById(id);
                return Ok(employee);
            }
            catch (ExceptionWhileFetching ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving employee");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest();
            try
            {
                _employeeService.AddItem(employeeDto);
                return Ok("employee added successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee");
            }
        }

        [HttpPut]
        public IActionResult UpdateEmployee(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            return BadRequest();

            try
            {
                _employeeService.UpdateItem(employeeDto);
                return Ok("employee updated successfully");
            }
            catch(ExceptionWhileUpdating ex)
            {
                return Conflict(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
            }
        }

        [HttpDelete("{EmployeeId:int}")]
        public IActionResult DeleteEmployee(string EmployeeId)
        {
           return BadRequest(); 
        }
    }
}
