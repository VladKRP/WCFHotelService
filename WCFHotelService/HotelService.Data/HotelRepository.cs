using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelService.Domain;
using System.Data;
using System.Data.Entity;

namespace HotelService.Data
{
    public class HotelRepository :Repository<Hotel>, IHotelRepository
    {
        public Hotel GetHotelWithRooms(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.Id.Equals(id));
            return hotel;
        }

        public IEnumerable<Room> GetHotelRooms(int id)
        {
            return _context.Hotels.FirstOrDefault(x => x.Id.Equals(id)).Rooms;
        }

        public IEnumerable<Room> GetReservedRooms(int id)
        {
            return _context.Hotels.FirstOrDefault(x => x.Id.Equals(id)).Rooms.Where(x => x.IsReserved.Equals(true));
        }

        public IEnumerable<Room> GetRoomsByType(int id, RoomType type)
        {
            return _context.Hotels.FirstOrDefault(x => x.Id.Equals(id)).Rooms.Where(x => x.Type.Id.Equals(type.Id));
        }

        public IEnumerable<Room> GetVacantRooms(int id)
        {
            return _context.Hotels.FirstOrDefault(x => x.Id.Equals(id)).Rooms.Where(x => x.IsReserved.Equals(false));
        }
    }
}
