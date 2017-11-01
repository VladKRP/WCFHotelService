using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelService.Data.Abstractions
{
    public interface IHotelRepository: IRepository<Hotel,int>, IDisposable
    {
        Hotel GetHotelWithRooms(int id);

        IQueryable<Room> GetVacantRooms();

        IQueryable<Room> GetReservedRooms();

        IQueryable<Room> GetRoomsByType(RoomType type);

        IQueryable<Room> GetVacantRoomsOfSpecialType(RoomType type);
    }
}
