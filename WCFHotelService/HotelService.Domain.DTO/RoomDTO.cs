using System;
using System.Collections.Generic;
using HotelService.Domain;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Domain.DTO
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string RoomType { get; set; }
        public decimal Cost { get; set; }
        public bool IsReserved { get; set; }
    }
}
