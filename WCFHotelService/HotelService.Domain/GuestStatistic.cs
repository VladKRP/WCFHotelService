using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain
{
    
    public class GuestStatistic
    {
        public int Id { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int ReservationCount { get; set; }
        public int RentDaysAmount { get; set; }
    }
}
