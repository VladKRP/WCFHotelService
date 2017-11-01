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
            var existingGuest = _context.Guests.Find(guest);
            if(existingGuest != null)
            {
                existingGuest.Type = type;
                _context.Entry(existingGuest).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }

        }
    }
}
