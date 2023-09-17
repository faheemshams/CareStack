using DataAccessLayer.Entities;
using BuisnessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Dto.ServiceDto;
using BuisnessLayer.Exceptions;

namespace BuisnessLayer.Services
{
    public class CabinService<T> : IService<CabinRoomDto>
    {
        private readonly IRepository<CabinRoom> _cabinRepository;
        private readonly IRepository<Employee> _employeeRepository;
        private readonly IRepository<Facility> _facilityRepository;

        public CabinService(IRepository<CabinRoom> cabinRepository, IRepository<Facility> facilityRepository, IRepository<Employee> employeeRepository)
        {
            _cabinRepository = cabinRepository;
            _employeeRepository = employeeRepository;
            _facilityRepository = facilityRepository;
        }

        public CabinRoomDto[] GetAllItems()
        {
            CabinRoom[] cabinRooms =  _cabinRepository.GetAllItems().ToArray();
            CabinRoomDto[] cabinDto = new CabinRoomDto[cabinRooms.Length];

            for(int i=0; i<cabinRooms.Length; i++)
            cabinDto[i] = ConvertCabinToCabinDto(cabinRooms[i]);

            return cabinDto;
        }

        public CabinRoomDto GetItemById(int cabinId)
        {
            var cabin = _cabinRepository.GetAllItems().FirstOrDefault(x => x.CabinId == cabinId);
            if (cabin == null)
                throw new ExceptionWhileFetching("Cabin room not found");
            else
                return ConvertCabinToCabinDto(cabin);
        }

        public void AddItem(CabinRoomDto cabin)
        {
            if (_facilityRepository.GetItemById(cabin.FacilityId) == null)
                throw new ExceptionWhileAdding("Facility not found");
            
            int cabinRoomCount =  _cabinRepository.GetAllItems().Where(x => x.FacilityId == cabin.FacilityId).ToArray().Length;

            CabinRoom newCabin = new CabinRoom()
            {
                CabinNumber = string.Format("C{0:D3}", cabinRoomCount + 1),
                FacilityId = cabin.FacilityId,
                EmployeeId = null
            };

            _cabinRepository.AddItem(newCabin);
        }

        public void UpdateItem(CabinRoomDto cabinDto)
        {
            var cabin = _cabinRepository.GetAllItems().FirstOrDefault(x => x.CabinId == cabinDto.CabinRoomId);
            var existingEmployee = _employeeRepository.GetItemById(cabinDto.EmployeeId);

            if (cabin == null)
                throw new ExceptionWhileFetching("Cabin not found");
            if (existingEmployee == null)
                throw new ExceptionWhileFetching("Employee not found");
            if (cabin.EmployeeId != null)
                throw new ExceptionWhileUpdating("Cabin already has an employee in it");
            if (existingEmployee.RoomTypeId != 1)
                throw new ExceptionWhileUpdating("The employee is already in another seat");

            cabin.EmployeeId = cabinDto.EmployeeId;
            existingEmployee.RoomTypeId = 3;

            _cabinRepository.UpdateItem(cabin);
            _employeeRepository.UpdateItem(existingEmployee);
        }
        private CabinRoomDto ConvertCabinToCabinDto(CabinRoom cabinRoom)
        {
            return new CabinRoomDto()
            {
                CabinRoomId = cabinRoom.CabinId,
                CabinNumber = cabinRoom.CabinNumber,
                EmployeeId = cabinRoom.EmployeeId,  
                FacilityId = cabinRoom.FacilityId,
            };
        }
        public void DeleteItem(string id)
        {
            /*var cabin = _cabinRepository.GetItemById(id);
            
            if (cabin == null)
            return null;

            var employee = _employeeRepository.GetItemById(cabin.EmployeeId);
            employee.RoomTypeId = 1;

            _cabinRepository.DeleteItem(id);
            _employeeRepository.UpdateItem(employee);
            */
        }
    }
}
