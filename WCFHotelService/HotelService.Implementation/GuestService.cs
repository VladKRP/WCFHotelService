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
        private readonly IGuestRepository _repository;

        public GuestService()
        {
            _repository = new GuestRepository();
        }

        public GuestService(IGuestRepository repository)
        {
            _repository = repository;
        }

        public Guest Get(int id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Guest> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(Guest guest)
        {
            _repository.Create(guest);
        }

        public void Delete(Guest guest)
        {
            _repository.Delete(guest);
        }

        public void Update(Guest guest)
        {
            _repository.Update(guest);
        }

        public void ChangeGuestStatusType(Guest guest, GuestType status)
        {
            _repository.ChangeGuestStatusType(guest, status);
        }

        protected virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
