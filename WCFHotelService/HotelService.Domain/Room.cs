using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HotelService.Domain
{
    [DataContract]
    public class Room
    {
        [Key]
        [DataMember]
        public int RoomId { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public RoomType RoomType { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public bool IsReserved { get; set; }

        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}