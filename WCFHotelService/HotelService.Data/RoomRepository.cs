using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain;

namespace HotelService.Data
{
    public class RoomRepository :Repository<Room>, IRoomRepository
    {
        //private readonly HotelAppContext _context;

        //public RoomRepository()
        //{
        //    _context = new HotelAppContext();
        //}

        //public RoomRepository(HotelAppContext context) { _context = context; }
        
    }
}
