using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelService.Data.Abstractions
{
    public interface IHotelRepository: IRepository<Hotel,int>, IDisposable
    {
        Hotel GetHotelWithRooms(int id);

        IEnumerable<Room> GetVacantRooms(int id);

        IEnumerable<Room> GetReservedRooms(int id);

        IEnumerable<Room> GetRoomsByType(int id, RoomType type);
    }
}
