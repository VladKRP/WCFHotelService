using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using HotelService.Data;
using HotelService.Domain.DTO;
using AutoMapper;
using HotelService.Contracts.Implementation.MapperProfile;

namespace HotelService.Contracts.Implementation
{
    public class HotelService : IHotelService
    {
        private readonly UnitOfWork _repository;
        private readonly IMapper _mapper;

        public HotelService()
        {
            _repository = new UnitOfWork();
            _mapper = HotelServiceMapper.Configure();
        }

        //public HotelService(IHotelRepository repository) { _repository = repository; }

        public HotelDTO Get(string id)
        {
            HotelDTO hotel = null;
            if(int.TryParse(id, out int value))
            {
                hotel = _mapper.Map<HotelDTO>(_repository.Hotels.Get(value));
            }
            return hotel;
        }

        public IEnumerable<HotelDTO> GetAll()
        {
            var hotels = _repository.Hotels.GetAll();
            return _mapper.Map<IEnumerable<HotelDTO>>(hotels);
        }

        public IEnumerable<HotelDTO> GetHotelsByCity(string city)
        {
            var hotels = _repository.Hotels.GetAll().Where(x => x.Address.City.Equals(city));
            return _mapper.Map<IEnumerable<HotelDTO>>(hotels);
        }


        public void Create(HotelDTO hotelDto)
        {
            var hotel = _mapper.Map<Hotel>(hotelDto);
            _repository.Hotels.Create(hotel);
        }

        public void Update(string id, HotelDTO hotel)
        {
            //var existingHotel = Get(id);
            //if(existingHotel != null)
            //{
            //    existingHotel.Address = hotel.Address;
            //    existingHotel.Rooms = existingHotel.Rooms;
            //    _repository.Hotels.Update(hotel);
            //}      
        }

        public void Delete(string id)
        {
            if(int.TryParse(id,out int value))
            {
                var hotel = _repository.Hotels.Get(value);
                if (hotel != null)
                    _repository.Hotels.Delete(hotel);
            }          
        }

        public IEnumerable<RoomDTO> GetHotelRooms(string id)
        {
            IEnumerable<RoomDTO> rooms = null;
            if (int.TryParse(id, out int value))
            {
                var hotel = _repository.Hotels.GetHotelWithRooms(value);
                rooms = _mapper.Map<IEnumerable<RoomDTO>>(hotel.Rooms);
            }
            return rooms;
        }

        public IQueryable<RoomDTO> GetReservedRooms(string id)
        {
            IEnumerable<RoomDTO> reservedRooms = null;
            if (int.TryParse(id, out int value))
                reservedRooms = _mapper.Map<IEnumerable<RoomDTO>>(_repository.Hotels.GetReservedRooms(value));
            return reservedRooms.AsQueryable();
        }

        public IQueryable<RoomDTO> GetVacantRooms(string id)
        {
            IEnumerable<RoomDTO> vacantRooms = null;
            if(int.TryParse(id, out int value))
            {
                var rooms = _repository.Hotels.GetVacantRooms(value);
                vacantRooms = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
            }             
            return vacantRooms.AsQueryable();
        }

        public IQueryable<RoomDTO> GetRoomsByType(string id, string type)
        {
            IEnumerable<RoomDTO> roomsDto = null;
            if(int.TryParse(id, out int value))
            {
                if (!string.IsNullOrEmpty(type))
                {
                    type = type.Where(x => char.IsLetter(x)).Aggregate("", (x, y) => x += y);
                    var roomType = _repository.RoomTypes.GetByName(type);
                    var rooms = _repository.Hotels.GetRoomsByType(value, roomType);
                    roomsDto = _mapper.Map<IEnumerable<RoomDTO>>(rooms);
                } 
            }
            return roomsDto.AsQueryable();
        }

        public IQueryable<RoomDTO> GetVacantRoomsOfSpecialType(string id, string type)
        {
            return GetRoomsByType(id, type).Where(x => !x.IsReserved);
        }

        protected  virtual void Dispose()
        {
            _repository.Dispose();
        }

        
    }
}
