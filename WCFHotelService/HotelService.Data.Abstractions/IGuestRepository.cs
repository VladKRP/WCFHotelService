using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain;

namespace HotelService.Data.Abstractions
{
    public interface IGuestRepository:IRepository<Guest,int>, IDisposable
    {
        void ChangeGuestStatusType(Guest guest, GuestType type);
        
    }
}
