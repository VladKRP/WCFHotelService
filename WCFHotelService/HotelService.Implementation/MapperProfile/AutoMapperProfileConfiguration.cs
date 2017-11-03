using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HotelService.Domain;
using HotelService.Domain.DTO;

namespace HotelService.Contracts.Implementation.MapperProfile
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() {
            CreateMap<Room, RoomDTO>()
                .ForMember(r => r.RoomType, opt => opt.MapFrom(x => x.Type.Name));
            CreateMap<RoomReservation, RoomReservationDTO>()
                .ForMember(r => r.GuestFullName, opt => opt.MapFrom(x => $"{x.Guest.Name} {x.Guest.Surname}"))
                .ForMember(r => r.RoomType, opt => opt.MapFrom(x => x.Room.Type.Name));
            CreateMap<Hotel, HotelDTO>();
        }

    }

    public class HotelServiceMapper
    {
        public static IMapper Configure()
        {
            var configurations = new AutoMapper.MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfile()));
            return configurations.CreateMapper();
        }
    }
}

