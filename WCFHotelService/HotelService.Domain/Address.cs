using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace HotelService.Domain
{
    [DataContract]
    public class Address
    {
        [Key]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string City { get; set; }
        [DataMember]
        public string Street { get; set; }
        [DataMember]
        public string PostalCode { get; set; }
    }
}