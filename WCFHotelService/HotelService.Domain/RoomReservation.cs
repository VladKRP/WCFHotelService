using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;

namespace HotelService.Domain
{
    [DataContract]
    public enum RoomReservationStatus
    {
        [EnumMember]
        Reserved = 0,
        [EnumMember]
        Passed = 1,
        [EnumMember]
        Rejected = 2
    }

    [DataContract]
    public class RoomReservation
    {
        [Key]
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        public int GuestId { get; set; }

        [DataMember]
        public virtual Guest Guest { get; set; }

        [DataMember]
        public int RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public DateTime BeginDate { get; set; }

        [DataMember]
        public DateTime EndDate { get; set; }

        [DataMember]
        public decimal Price { get; set; }

        [DataMember]
        public RoomReservationStatus ReservationStatus { get; set; }

        public RoomReservation()
        {
            CalculatePrice();
        }

        private void CalculatePrice()
        {
            var days = EndDate.Subtract(BeginDate).Days;
            Price = Room.Cost * days;
        }

    }
}
