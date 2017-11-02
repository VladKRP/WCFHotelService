using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelService.Data.Abstractions
{
    public interface IHotelRepository: IRepository<Hotel,int>, IDisposable
    {
        Hotel GetHotelWithRooms(int id);

        IQueryable<Room> GetVacantRooms(int id);

        IQueryable<Room> GetReservedRooms(int id);

        IQueryable<Room> GetRoomsByType(int id, RoomType type);

        IQueryable<Room> GetVacantRoomsOfSpecialType(int id, RoomType type);
    }
}
