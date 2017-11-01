using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain
{
    public class Discount
    {
        public int DiscountId { get; set; }

        public GuestType GuestType { get; set; }

        public double Rate { get; set; }
    }
}
