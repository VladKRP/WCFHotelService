using HotelService.Data;
using HotelService.Data.Abstractions;
using HotelService.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;

namespace HotelService.Contracts.Implementation
{
    public class RoomReservationService: IRoomReservationService
    {
        private readonly UnitOfWork _repository;

        public RoomReservationService() {
            _repository = new UnitOfWork();
        }

        //public RoomReservationService(IRoomReservationRepository repository) { _roomReservationRepository = repository; }


        public RoomReservation Get(string id)
        {
            RoomReservation reservation = null;
            if(int.TryParse(id, out int value))
            {
                reservation = _repository.RoomReservations.Get(value);
            }
            return reservation;
        }

        public IEnumerable<RoomReservation> GetAll()
        {
            return _repository.RoomReservations.GetAll();
        }

        public void Create(RoomReservation reservation)
        {
            _repository.RoomReservations.Create(reservation);
        }

        public void Update(string id, RoomReservation reservation)
        {
            var existingReservation = Get(id);
            if(existingReservation != null)
                _repository.RoomReservations.Update(reservation);
        }

        public void Delete(string id)
        {
            var reservation = Get(id);
            if(reservation != null)
                _repository.RoomReservations.Delete(reservation);
        }

        public void Extend(string reservationId, int days)
        {
            var reservation = Get(reservationId);
            if (days <= 0)
                throw new FaultException("Number of days for reservation must be more than zero.");
            else if (reservation.Room == null)
                throw new FaultException("The room is not specified");
            else if (reservation.Guest == null)
                throw new FaultException("Guest is not specified");
            else
                _repository.RoomReservations.Extend(reservation, days);
        }

        public void Reject(string reservationId)
        {
            var reservation = Get(reservationId);
            if(reservation != null)
                _repository.RoomReservations.Reject(reservation);
        }

        public void Reserve(RoomReservation reservation)
        {
            if(reservation != null)
                _repository.RoomReservations.Reserve(reservation);
        }

        protected virtual void Dispose(bool disposing)
        {
            _repository.Dispose();
        }

        public void ChangeRoomState(string roomId, bool isReserved)
        {
            if(int.TryParse(roomId, out int value))
            {
                var room = _repository.Rooms.Get(value);
                _repository.RoomReservations.ChangeRoomState(room, isReserved);
            }
        }
    }
}
