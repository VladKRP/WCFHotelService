using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelService.Domain;
using System.Data;

namespace HotelService.Data
{
    public class HotelRepository :Repository<Hotel>, IHotelRepository
    {


        //private HotelAppContext _context;

        //public HotelRepository() { _context = new HotelAppContext(); }

        //public HotelRepository(HotelAppContext context) { _context = context; }

        public Hotel GetHotelWithRooms(int id)
        {
            var hotels = _context.Hotels.Include("Rooms").ToList();
            //return _context.Hotels.FirstOrDefault(x => x.HotelId.Equals(id));
            throw new NotImplementedException();
        }

        public IQueryable<Room> GetReservedRooms()
        {
            return _context.Rooms.Where(x => x.IsReserved.Equals(true));
        }

        public IQueryable<Room> GetRoomsByType(RoomType type)
        {
            return _context.Rooms.Where(x => x.RoomType.Equals(type));
        }

        public IQueryable<Room> GetVacantRooms()
        {
            return _context.Rooms.Where(x => x.IsReserved.Equals(false));
        }

        public IQueryable<Room> GetVacantRoomsOfSpecialType(RoomType type)
        {
            return GetVacantRooms().Where(x => x.RoomType.Equals(type));
        }
    }
}
