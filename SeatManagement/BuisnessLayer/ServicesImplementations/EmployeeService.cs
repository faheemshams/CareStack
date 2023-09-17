using BuisnessLayer.Exceptions;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class EmployeeService<T> : IService<EmployeeDto>
    {
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Department> _departmentRepository;

        public EmployeeService(IRepository<Employee> repository, IRepository<Department> departmentRepository)
        {
            this._employeeRepository = repository;
            _departmentRepository = departmentRepository;
        }

        public EmployeeDto[] GetAllItems()
        {
            Employee[] employees =  _employeeRepository.GetAllItems().ToArray();
            EmployeeDto[] employeeDtos = new EmployeeDto[employees.Length];

            for(int i = 0; i < employees.Length; i++)
            {
                employeeDtos[i] = ConvertEmployeToEmployeeDto(employees[i]);
            }
            return employeeDtos;
        }

        public EmployeeDto GetItemById(int employeeId)
        {
            var employee = _employeeRepository.GetItemById(employeeId);
            if (employee == null)
                throw new ExceptionWhileFetching("Employee not found");
            else
                return ConvertEmployeToEmployeeDto(employee);
        }

        public void AddItem(EmployeeDto employeeDto)
        {
            if (_departmentRepository.GetItemById(employeeDto.DeptId) == null)
                throw new ExceptionWhileAdding("Department not found");
            Employee employee = new Employee()
            {
                EmployeeName = employeeDto.EmployeeName,
                DeptId = employeeDto.DeptId,
                RoomTypeId = 1                          
            };
            _employeeRepository.AddItem(employee);
        }

        public void UpdateItem(EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetItemById(employeeDto.EmployeeId);

            if (employee == null)
                throw new ExceptionWhileUpdating("Employee not found");

            employee.EmployeeName = employeeDto.EmployeeName;
            employee.DeptId = employeeDto.DeptId;
            _employeeRepository.UpdateItem(employee);
        }
        private EmployeeDto ConvertEmployeToEmployeeDto(Employee employee)
        {
           return new EmployeeDto()
            {
                EmployeeId = employee.EmployeeId,
                EmployeeName = employee.EmployeeName,
                DeptId= employee.DeptId,
            };
        }
        public void DeleteItem(string id)
        {
            /*refactor 
            var employee = _employeeRepository.GetItemById(id);

            if (employee == null)
            return null;

            _employeeRepository.DeleteItem(id);
            return employee;
            */
        }
    }
}
