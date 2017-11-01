using HotelService.Domain;
using System;

namespace HotelService.Data.Abstractions
{
    public interface IRoomReservationRepository: IRepository<RoomReservation,int>, IDisposable
    {
        void ChangeRoomState(Room room, bool isReserved);
        void Reserve(RoomReservation reservation);
        void Reject(RoomReservation reservation);
        void Extend(RoomReservation reservation, int days);
    }
}
