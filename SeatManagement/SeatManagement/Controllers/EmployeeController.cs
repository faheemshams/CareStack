using Microsoft.AspNetCore.Mvc;

using DataAccessLayer.Entities;

using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Dto;

namespace PresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService<Employee> _employeeService;

        public EmployeeController(IService<Employee> employeeService)
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

                if (employee == null)
                    return NotFound();

                return Ok(employee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error while retrieving employee");
            }
        }

        [HttpPost]
        public IActionResult CreateEmployee(CreateEmployeeDto employeeDto)
        {
            try
            {
                if (employeeDto == null)
                return BadRequest();

                Employee employee = new Employee()
                {
                    EmployeeName = employeeDto.EmployeeName,
                    DeptId = employeeDto.DeptId,
                    RoomTypeId = 1
                };

                var createdEmployee = _employeeService.AddItem(employee);

                if (createdEmployee == null)
                    return StatusCode(StatusCodes.Status500InternalServerError, "Cannot create employee");

                return Ok(createdEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error creating employee");
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateEmployee(int id, UpdateEmployeeDto employeeDto)
        {
            if (employeeDto == null)
                return BadRequest();

            Employee employee = new Employee()
            {
                EmployeeId = id,
                EmployeeName = employeeDto.EmployeeName,
                DeptId = employeeDto.DeptId,
                RoomTypeId = employeeDto.RoomTypeId,
            };

            try
            {
                var existingEmployee = _employeeService.GetItemById(id);

                if (existingEmployee == null)
                    return NotFound("Employee not found");

                employee.EmployeeId = id;

                var updatedEmployee = _employeeService.UpdateItem(employee);

                if (updatedEmployee == null)
                    return NotFound("Employee not found");

                return Ok(updatedEmployee);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Error updating employee");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteEmployee(int id)
        {
            try
            {
                var deletedEmployee = _employeeService.DeleteItem(id);

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
