using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeatManagementConsole.Interfaces
{
    internal interface IAllocationManagerApi<T> where T : class
    {
        string AddItem(T data);
        List<T> GetItems();
        T GetItemById(int id);
        string UpdateItem(T data);
    }
}
