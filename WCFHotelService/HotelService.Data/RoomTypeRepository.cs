using HotelService.Data.Abstractions;
using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Data
{
    public class RoomTypeRepository : Repository<RoomType>, IRoomTypeRepository
    {
        public RoomType GetByName(string name)
        {
            return _context.RoomTypes.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
