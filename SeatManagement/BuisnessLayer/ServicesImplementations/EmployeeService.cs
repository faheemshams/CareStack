using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Entities;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class EmployeeService<T> : IService<Employee>
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

        public Employee GetItemById(int id)
        {
            return _employeeRepository.GetItemById(id);
        }

        public Employee AddItem(Employee employee)
        {
            _employeeRepository.AddItem(employee);
            return employee;
        }

        public Employee DeleteItem(int id)
        {
            var employee = _employeeRepository.GetItemById(id);

            if (employee == null)
            return null;

            _employeeRepository.DeleteItem(id);
            return employee;
        }

        public Employee UpdateItem(Employee newEmployee)
        {
            var existingEmployee = _employeeRepository.GetItemById(newEmployee.EmployeeId);

            if (existingEmployee == null)
            {
                return null;
            }

            existingEmployee.EmployeeName = newEmployee.EmployeeName;
            existingEmployee.RoomTypeId = newEmployee.RoomTypeId;
            existingEmployee.DeptId = newEmployee.DeptId;
            _employeeRepository.UpdateItem(existingEmployee);
            return newEmployee;
        }
    }
}
