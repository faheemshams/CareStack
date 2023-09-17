using Microsoft.AspNetCore.Mvc;
using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<EmployeeDto,Employee> _employeeService;

        public EmployeeController(IService<EmployeeDto, Employee> employeeService)
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

        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            try
            {
                var employee = _employeeService.GetItemById(id);

                if (employee == null)
                return NotFound();
                else
                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving employee");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(EmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto == null)
                return BadRequest();

                var createdEmployee = _employeeService.AddItem(employeeDto);

                if (createdEmployee == null)
                return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create employee");

                return Ok(createdEmployee);
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
               var updatedEmployee = _employeeService.UpdateItem(employeeDto);

                if (updatedEmployee == null)
                return NotFound("Employee not found");

                return Ok(updatedEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
            }
        }

        [HttpDelete("{EmployeeId}")]
        public IActionResult DeleteEmployee(string EmployeeId)
        {
            try
            {
                var deletedEmployee = _employeeService.DeleteItem(EmployeeId);

                if (deletedEmployee == null)
                return NotFound("Employee not found");

                return Ok("Employee deleted successfully");
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error deleting employee");
            }
        }
    }
}
