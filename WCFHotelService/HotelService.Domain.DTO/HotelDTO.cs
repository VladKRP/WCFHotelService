using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public Address Address { get; set; }

        public IEnumerable<RoomDTO> Rooms { get; set; }
    }
}
