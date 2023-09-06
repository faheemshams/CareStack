using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    internal interface IAllocationManagerApi<T> where T : class
    {
        string CreateData(T data);
        List<T> GetData();
        string Allocate(int id, T data);
        void Deallocate(T data);
        void DeleteData(T data);
    }
}
