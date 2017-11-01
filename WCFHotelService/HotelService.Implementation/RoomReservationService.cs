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
        private readonly IRoomReservationRepository _repository;

        public RoomReservationService() { _repository = new RoomReservationRepository(); }

        public RoomReservationService(IRoomReservationRepository repository) { _repository = repository; }


        public RoomReservation Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<RoomReservation> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(RoomReservation reservation)
        {
            _repository.Create(reservation);
        }

        public void Update(RoomReservation reservation)
        {
            _repository.Update(reservation);
        }

        public void Delete(RoomReservation reservation)
        {
            _repository.Delete(reservation);
        }

        public void Extend(RoomReservation reservation, int days)
        {
            if (days <= 0)
                throw new FaultException("Number of days for reservation must be more than zero.");
            else if (reservation.Room == null)
                throw new FaultException("The room is not specified");
            else if (reservation.Guest == null)
                throw new FaultException("Guest is not specified");
            else
                _repository.Extend(reservation, days);
        }

        public void Reject(RoomReservation reservation)
        {
            _repository.Reject(reservation);
        }

        public void Reserve(RoomReservation reservation)
        {
            _repository.Reserve(reservation);
        }

        protected virtual void Dispose(bool disposing)
        {
            _repository.Dispose();
        }

        public void ChangeRoomState(Room room, bool isReserved)
        {
            _repository.ChangeRoomState(room, isReserved);
        }
    }
}
