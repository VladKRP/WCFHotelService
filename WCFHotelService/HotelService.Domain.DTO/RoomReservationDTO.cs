using System;

namespace HotelService.Domain.DTO
{
    public class RoomReservationDTO
    {
        public int Id { get; set; }

        public string GuestFullName { get; set; }

        public string RoomNumber { get; set; }
        public string RoomType { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        public RoomReservationStatus ReservationStatus { get; set; }
    }
}
