using HotelService.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using HotelService.Data;

namespace HotelService.Contracts.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService() { _repository = new RoomRepository(); }

        public RoomService(IRoomRepository repository)
        {
            _repository = repository;
        }

        public Room Get(int id)
        {
            //return _repository.Get(id);
            var room = _repository.Get(id);
            return room;
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(Room room)
        {
            _repository.Create(room);
        }

        public void Update(Room room)
        {
            _repository.Update(room);
        }

        public void Delete(Room room)
        {
            _repository.Delete(room);
        }

        protected virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
