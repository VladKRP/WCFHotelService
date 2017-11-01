using Autofac;
using HotelService.Data;
using HotelService.Data.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelService.Contracts.Implementation
{
    public static class Bootstraper
    {
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<RoomService>().As<IRoomService>();
            builder.RegisterType<GuestService>().As<IGuestService>();

            builder.RegisterType<RoomRepository>().As<IRoomRepository>();

            return builder.Build();
        }
       
    }
}
