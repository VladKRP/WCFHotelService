using HotelService.Domain;
using System;
using System.Collections.Generic;

namespace HotelService.Data.Abstractions
{
    public interface IRoomReservationRepository: IRepository<RoomReservation,int>, IDisposable
    {
        void ChangeRoomState(Room room, bool isReserved);
        IEnumerable<RoomReservation> GetReservationsByHotel(int id);
        void Reserve(RoomReservation reservation);
        void Reject(RoomReservation reservation);
        void Extend(RoomReservation reservation, int days);
    }
}
