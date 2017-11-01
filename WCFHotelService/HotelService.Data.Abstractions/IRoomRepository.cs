using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Data.Abstractions
{
    public interface IRoomRepository:IRepository<Room,int>, IDisposable
    {
       
        
    }
}
