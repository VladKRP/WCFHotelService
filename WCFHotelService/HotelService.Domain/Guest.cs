using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain
{
    public enum GuestType
    {
        Simple,
        Vip
    }

    [DataContract]
    public class Guest
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        [DataMember]
        public GuestType Type { get; set; } = GuestType.Simple;
        [DataMember]
        public string PassportNumber { get; set; }
    }
}
