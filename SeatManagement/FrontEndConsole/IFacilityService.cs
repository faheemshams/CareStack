using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontEndConsole
{
    public interface IFacilityService
    {
        Task<IEnumerable<FacilityModel>> GetAllAsync();
        Task<FacilityModel> GetByIdAsync(int id);
        Task<FacilityModel> CreateAsync(FacilityModel facility);
    }
}
