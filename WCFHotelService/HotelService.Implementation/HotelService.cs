using System;
using System.Collections.Generic;
using System.Linq;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using HotelService.Data;

namespace HotelService.Contracts.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _repository;

        public HotelService()
        {
            _repository = new HotelRepository();
        }

        public HotelService(IHotelRepository repository) { _repository = repository; }

        public Hotel Get(string id)
        {
            int idValue = int.Parse(id);
            return _repository.Get(idValue);
        }

        public IEnumerable<Hotel> GetAll()
        {
            return _repository.GetAll();
        }

        public void Create(Hotel hotel)
        {
            _repository.Create(hotel);
        }

        public void Update(Hotel hotel)
        {
            _repository.Update(hotel);
        }

        public void Delete(string id)
        {
            var hotel = Get(id);
            _repository.Delete(hotel);
        }

        public IQueryable<Room> GetReservedRooms()
        {
            return _repository.GetReservedRooms();
        }

        public IQueryable<Room> GetRoomsByType(RoomType type)
        {
            return _repository.GetRoomsByType(type);
        }

        public IEnumerable<Room> GetHotelRooms(string id)
        {
            int parsedId = int.Parse(id);
            var hotelRooms = _repository.GetHotelWithRooms(parsedId);
            return hotelRooms.Rooms;
        }

        public IQueryable<Room> GetVacantRooms()
        {
            return _repository.GetVacantRooms();
        }

        public IQueryable<Room> GetVacantRoomsOfSpecialType(RoomType type)
        {
            return _repository.GetVacantRoomsOfSpecialType(type);
        }

        protected  virtual void Dispose()
        {
            _repository.Dispose();
        }
     
    }
}
