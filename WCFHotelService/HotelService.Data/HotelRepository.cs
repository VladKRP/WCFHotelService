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


        //private HotelAppContext _context;

        //public HotelRepository() { _context = new HotelAppContext(); }

        //public HotelRepository(HotelAppContext context) { _context = context; }

        public Hotel GetHotelWithRooms(int id)
        {
            var hotel = _context.Hotels.FirstOrDefault(x => x.HotelId.Equals(id));
            return hotel;
        }

        public IQueryable<Room> GetHotelRooms(int id)
        {
            return GetHotelWithRooms(id).Rooms.AsQueryable();
        }

        public IQueryable<Room> GetReservedRooms(int id)
        {
            return GetHotelRooms(id).Where(x => x.IsReserved.Equals(true));
        }

        public IQueryable<Room> GetRoomsByType(int id, RoomType type)
        {
            return GetHotelRooms(id).Where(x => x.RoomType.Equals(type));
        }

        public IQueryable<Room> GetVacantRooms(int id)
        {
            return GetHotelRooms(id).Where(x => x.IsReserved.Equals(false));
        }

        public IQueryable<Room> GetVacantRoomsOfSpecialType(int id, RoomType type)
        {
            return GetVacantRooms(id).Where(x => x.RoomType.Equals(type));
        }
    }
}
