using System.Collections.Generic;

namespace HotelService.Domain.DTO
{
    public class HotelDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Address Address { get; set; }

        public IEnumerable<RoomDTO> Rooms { get; set; }
    }
}
