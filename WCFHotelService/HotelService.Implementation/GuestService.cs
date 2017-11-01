using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelService.Domain;
using HotelService.Data.Abstractions;

namespace HotelService.Contracts.Implementation
{
    public class GuestService : IGuestService
    {
        private readonly IGuestRepository _repository;

        public GuestService(IGuestRepository repository)
        {
            _repository = repository;
        }

        public Guest Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Guest> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Create(Guest guest)
        {
            throw new NotImplementedException();
        }

        public void Delete(Guest guest)
        {
            throw new NotImplementedException();
        }

        public void Update(Guest guest)
        {
            throw new NotImplementedException();
        }

        public void ChangeGuestStatusType(Guest guest, GuestType status)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
