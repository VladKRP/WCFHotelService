using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace HotelService.Domain
{
    [DataContract]
    public class Room
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Number { get; set; }
        [DataMember]
        public RoomType Type { get; set; }
        [DataMember]
        public decimal Cost { get; set; }
        [DataMember]
        public bool IsReserved { get; set; }

        public int? HotelId { get; set; }
        public Hotel Hotel { get; set; }

    }
}