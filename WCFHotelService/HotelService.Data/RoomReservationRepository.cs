using HotelService.Data.Abstractions;
using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Data
{
    public class RoomReservationRepository:Repository<RoomReservation>, IRoomReservationRepository, IDisposable
    {
        //private readonly HotelAppContext _context;

        //public RoomReservationRepository()
        //{
        //    _context = new HotelAppContext();
        //}

        //public RoomReservationRepository(HotelAppContext context) { _context = context; }

        public void ChangeRoomState(Room room, bool isReserved)
        {
            var currentRoom = _context.Rooms.Find(room);
            if (currentRoom != null)
            {
                currentRoom.IsReserved = isReserved;
                _context.Entry<Room>(currentRoom).State = System.Data.Entity.EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void Extend(RoomReservation reservation, int days)
        {
            var currentReservation = _context.RoomReservations.Find(reservation);
            currentReservation.Days += days;
            currentReservation.EndDate = currentReservation.EndDate.Add(new TimeSpan(days, 0, 0, 0, 0));
            _context.SaveChanges();
        }

        public IEnumerable<RoomReservation> GetReservationsByHotel(int id)
        {
            var hotelRooms = _context.Hotels.FirstOrDefault(x => x.Id.Equals(id)).Rooms;
            var hotelReservations = from hotelRoom in hotelRooms
                                    from reservation in _context.RoomReservations
                                    where reservation.RoomId == hotelRoom.Id
                                    select reservation;
            return hotelReservations;
        }

        public void Reject(RoomReservation reservation)
        {
            var currentReservation = _context.RoomReservations.Find(reservation);
            if (currentReservation != null)
            {
                ChangeRoomState(currentReservation.Room, false);
                reservation.ReservationStatus = RoomReservationStatus.Rejected;
                _context.RoomReservations.Remove(currentReservation);
            }
            _context.SaveChanges();
        }

        public void Reserve(RoomReservation reservation)
        {
            var existingReservation = _context.RoomReservations.Find(reservation);
            if (existingReservation == null)
            {
                ChangeRoomState(reservation.Room, true);
                reservation.ReservationStatus = RoomReservationStatus.Reserved;
                reservation.EndDate = reservation.BeginDate.Add(new TimeSpan(reservation.Days, 0, 0, 0));
                _context.RoomReservations.Add(reservation);
            }
            _context.SaveChanges();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
            base.Dispose();
        }
    }
}
