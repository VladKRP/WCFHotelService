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

        public Hotel Get(int id)
        {
            return _repository.Get(id);
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

        public void Delete(Hotel hotel)
        {
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

        public IEnumerable<Room> GetHotelRooms(int id)
        {
            var hotelRooms = _repository.GetHotelWithRooms(id);
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
