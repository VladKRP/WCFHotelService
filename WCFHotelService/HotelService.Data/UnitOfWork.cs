using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Data
{
    public class UnitOfWork: IDisposable
    {
        private IGuestRepository _guestRepository;
        private IHotelRepository _hotelRepository;
        private IRoomRepository _roomRepository;
        private IRoomReservationRepository _roomReservationRepository;

        public IGuestRepository Guests
        {
            get
            {
                if (_guestRepository == null)
                    _guestRepository = new GuestRepository();
                return _guestRepository;
            }
        }

        public IRoomRepository Rooms
        {
            get
            {
                if (_roomRepository == null)
                    _roomRepository = new RoomRepository();
                return _roomRepository;
            }
        }

        public IHotelRepository Hotels
        {
            get
            {
                if (_hotelRepository == null)
                    _hotelRepository = new HotelRepository();
                return _hotelRepository;
            }
        }

        public IRoomReservationRepository RoomReservations
        {
            get
            {
                if (_roomReservationRepository == null)
                    _roomReservationRepository = new RoomReservationRepository();
                return _roomReservationRepository;
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    _roomReservationRepository.Dispose();
                    _roomRepository.Dispose();
                    _hotelRepository.Dispose();
                    _guestRepository.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
        }
    }
}
