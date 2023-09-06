using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuisnessLayer.ServiceInterfaces
{
    public interface IReport<T> where T : class 
    {
        T[] GetView();
    }
}
