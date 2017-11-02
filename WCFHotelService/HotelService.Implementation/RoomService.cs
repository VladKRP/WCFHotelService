using HotelService.Contracts;
using System;
using System.Collections.Generic;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using HotelService.Data;

namespace HotelService.Contracts.Implementation
{
    public class RoomService : IRoomService
    {
        private readonly UnitOfWork _repository;

        public RoomService() { _repository = new UnitOfWork(); }

        //public RoomService(IRoomRepository repository)
        //{
        //    _repository = repository;
        //}

        public Room Get(string id)
        {
            Room room = null;
            if(int.TryParse(id, out int value))
            {
                room = _repository.Rooms.Get(value);
            }
            return room;
        }

        public IEnumerable<Room> GetAll()
        {
            return _repository.Rooms.GetAll();
        }

        public void Create(Room room)
        {
            _repository.Rooms.Create(room);
        }

        public void Update(string id, Room room)
        {
            var existingRoom = Get(id);
            if (existingRoom != null)
            {
                existingRoom.Number = room.Number;
                existingRoom.RoomType = room.RoomType;
                existingRoom.Cost = room.Cost;
                existingRoom.IsReserved = room.IsReserved;
                _repository.Rooms.Update(existingRoom);
            }
            
        }

        public void Delete(string id)
        {
            var room = Get(id);
            if(room != null)
                _repository.Rooms.Delete(room);
        }

        protected virtual void Dispose()
        {
            _repository.Dispose();
        }

    }
}
