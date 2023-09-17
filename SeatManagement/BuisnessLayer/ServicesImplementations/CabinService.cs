using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;

namespace BuisnessLayer.Services
{
    public class CabinService<Tin, Tout> : IService<CabinRoomDto, CabinRoom>
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

        public CabinRoom GetItemById(int cabinId)
        {
            return _cabinRepository.GetAllItems().FirstOrDefault(x => x.CabinId == cabinId);
        }

        public CabinRoom AddItem(CabinRoomDto cabin)
        {
            if (cabin == null)
            return null;

            int cabinRoomCount =  _cabinRepository.GetAllItems().Where(x => x.FacilityId == cabin.FacilityId).ToArray().Length;

            CabinRoom newCabin = new CabinRoom()
            {
                CabinNumber = string.Format("C{0:D3}", cabinRoomCount + 1),
                FacilityId = cabin.FacilityId,
                EmployeeId = null
            };

            _cabinRepository.AddItem(newCabin);
            return newCabin;
        }

        public CabinRoom DeleteItem(string id)
        {
            /*var cabin = _cabinRepository.GetItemById(id);
            
            if (cabin == null)
            return null;

            var employee = _employeeRepository.GetItemById(cabin.EmployeeId);
            employee.RoomTypeId = 1;

            _cabinRepository.DeleteItem(id);
            _employeeRepository.UpdateItem(employee);
            return cabin;*/
            return null;
        }

        public CabinRoom UpdateItem(CabinRoomDto cabinDto)
        {
            var cabin = _cabinRepository.GetAllItems().FirstOrDefault(x => x.CabinId == cabinDto.CabinRoomId);
            var existingEmployee = _employeeRepository.GetItemById(cabinDto.EmployeeId);

            if (cabin?.EmployeeId != null || existingEmployee?.RoomTypeId != 1)
            return null;

            cabin.EmployeeId = cabinDto.EmployeeId;
            existingEmployee.RoomTypeId = 3;

            _cabinRepository.UpdateItem(cabin);
            _employeeRepository.UpdateItem(existingEmployee);   
           
            return cabin;
        }
    }
}
