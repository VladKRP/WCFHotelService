using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using HotelService.Data;

namespace HotelService.Contracts.Implementation
{
    public class GuestService : IGuestService
    {
        private readonly UnitOfWork _repository;

        public GuestService()
        {
            _repository = new UnitOfWork();
        }

        //public GuestService(IGuestRepository repository)
        //{
        //    _repository = repository;
        //}

        public Guest Get(string id)
        {
            Guest guest = null;
            if (int.TryParse(id, out int value))
                guest = _repository.Guests.Get(value);
            return guest;
        }

        public IEnumerable<Guest> GetAll()
        {
            return _repository.Guests.GetAll();
        }

        public void Create(Guest guest)
        {
            _repository.Guests.Create(guest);
        }

        public void Delete(string id)
        {
            var guest = Get(id);
            if(guest != null)
            {
                _repository.Guests.Delete(guest);
            }     
        }

        public void Update(string id, Guest guest)
        {
            var existingGuest = Get(id);
            existingGuest.Name = guest.Name;
            existingGuest.Surname = guest.Surname;
            existingGuest.PassportNumber = guest.PassportNumber;
            _repository.Guests.Update(existingGuest);
        }

        public void ChangeGuestStatusType(string id, GuestType status)
        {
            var guest = Get(id);
            if(guest != null)
            {
                if(status == GuestType.Simple || status == GuestType.Vip)
                    _repository.Guests.ChangeGuestStatusType(guest, status);
            }
                
        }

        protected virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
