using Autofac;
using HotelService.Contracts;
using HotelService.Contracts.Implementation;
using HotelService.Data;
using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Service
{
    public static class Bootstraper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RoomService>().As<IRoomService>().InstancePerLifetimeScope();
            builder.RegisterType<GuestService>().As<IGuestService>().InstancePerLifetimeScope();

            builder.RegisterType<RoomRepository>().As<IRoomRepository>().InstancePerLifetimeScope();
            builder.RegisterType<HotelRepository>().As<IHotelRepository>().InstancePerLifetimeScope();
            builder.RegisterType<RoomReservationRepository>().As<IRoomReservationRepository>().InstancePerLifetimeScope();
            builder.RegisterType<GuestRepository>().As<IGuestRepository>().InstancePerLifetimeScope();

            return builder.Build();
        }
       
    }
}
