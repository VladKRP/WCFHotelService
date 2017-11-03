using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HotelService.Domain
{
    [DataContract]
    public class Hotel
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public virtual Address Address { get; set; }     
        [DataMember]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
