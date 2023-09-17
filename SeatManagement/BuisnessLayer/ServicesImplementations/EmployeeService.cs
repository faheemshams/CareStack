using BuisnessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class EmployeeService<Tin, Tout> : IService<EmployeeDto, Employee>
    {
        private readonly IRepository<Employee> _employeeRepository;

        public EmployeeService(IRepository<Employee> repository)
        {
            this._employeeRepository = repository;
        }

        public Employee[] GetAllItems()
        {
            return _employeeRepository.GetAllItems().ToArray();
        }

        public Employee GetItemById(int employeeId)
        {
            return _employeeRepository.GetItemById(employeeId);
        }

        public Employee AddItem(EmployeeDto employeeDto)
        {
            if (employeeDto == null)
            return null;

            Employee employee = new Employee()
            {
                EmployeeName = employeeDto.EmployeeName,
                DeptId = employeeDto.DeptId,
                RoomTypeId = 1                          //default value -> not allocated to any room
            };
                                
            _employeeRepository.AddItem(employee);
            return employee;
        }

        public Employee DeleteItem(string id)
        {
            /*refactor 
            var employee = _employeeRepository.GetItemById(id);

            if (employee == null)
            return null;

            _employeeRepository.DeleteItem(id);
            return employee;
            */
            return null;
        }

        public Employee UpdateItem(EmployeeDto employeeDto)
        {
            var employee = _employeeRepository.GetItemById(employeeDto.EmployeeId);

            if (employee == null)
            return null;

            employee.EmployeeName = employeeDto.EmployeeName;
            employee.DeptId = employeeDto.DeptId;
            //existingEmployee.RoomTypeId = newEmployee.RoomTypeId;            need to change allocation too

            _employeeRepository.UpdateItem(employee);
            return employee;
        }
    }
}
