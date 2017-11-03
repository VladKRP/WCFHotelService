using System;
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
        public int Id { get; set; }
        [DataMember]
        public virtual Address Address { get; set; }
        [DataMember]
        public virtual ICollection<Room> Rooms { get; set; }
    }
}
