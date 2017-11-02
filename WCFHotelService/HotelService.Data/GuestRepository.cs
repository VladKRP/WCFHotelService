using HotelService.Data.Abstractions;
using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Data
{
    public class GuestRepository : Repository<Guest>, IGuestRepository
    {
        public void ChangeGuestStatusType(Guest guest, GuestType type)
        {
            guest.Type = type;
            _context.Entry(guest).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
