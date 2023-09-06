using DataAccessLayer.Entities;
using BuisnessLayer.ServiceInterfaces;
using DataAccessLayer.Interfaces;

namespace BuisnessLayer.Services
{
    public class CabinService<T> : IService<CabinRoom>
    {
        private readonly IRepository<CabinRoom> _cabinRepository;
        private readonly IRepository<Employee> _employeeRepository;

        public CabinService(IRepository<CabinRoom> cabinRepository, IRepository<Employee> employeeRepository)
        {
            _cabinRepository = cabinRepository;
            _employeeRepository = employeeRepository;
        }

        public CabinRoom[] GetAllItems()
        {
            return _cabinRepository.GetAllItems().ToArray();
        }

        public CabinRoom GetItemById(int id)
        {
            return _cabinRepository.GetItemById(id);
        }

        public CabinRoom AddItem(CabinRoom cabin)
        {
            if (cabin == null)
            return null;

            cabin.EmployeeId = null;

            _cabinRepository.AddItem(cabin);
            return cabin;
        }

        public CabinRoom DeleteItem(int id)
        {
            var cabin = _cabinRepository.GetItemById(id);

            if (cabin == null)
                return null;

            _cabinRepository.DeleteItem(id);
            return cabin;
        }

        public CabinRoom UpdateItem(CabinRoom newCabin)
        {
            var existingCabin = _cabinRepository.GetItemById(newCabin.CabinId);
            var existingEmployee = _employeeRepository.GetItemById(newCabin.EmployeeId);

            if (existingCabin == null || existingEmployee == null)
            {
                return null;
            }

            existingCabin.CabinName = newCabin.CabinName;
            existingCabin.FacilityId = newCabin.FacilityId; 
            existingCabin.EmployeeId = newCabin.EmployeeId;
            existingEmployee.RoomTypeId = 3;

            _cabinRepository.UpdateItem(existingCabin);
            _employeeRepository.UpdateItem(existingEmployee);   
           
            return newCabin;
        }
    }
}
