﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain
{
    [DataContract]
    public class Hotel
    {
        [Key]
        [DataMember]
        public int HotelId { get; set; }
        [DataMember]
        public Address Address { get; set; }
        [DataMember]
        public IEnumerable<Room> Rooms { get; set; }
    }
}
