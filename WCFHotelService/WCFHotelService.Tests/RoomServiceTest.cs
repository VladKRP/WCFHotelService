using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using HotelService.Contracts;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;

namespace WCFHotelService.Tests
{
    [TestClass]
    public class RoomServiceTest
    {
        private readonly string roomUrl = "http://localhost:52786/RoomService.svc";
        private readonly ChannelFactory<IRoomService> channelFactory;
        private readonly IRoomService roomClient;
        //private readonly Mock<IRoomRepository> mock = new Mock<IRoomRepository>(rooms);
        private static IEnumerable<RoomReservation> rooms = new List<RoomReservation>()
        {
            new RoomReservation(){},
            new RoomReservation(){},
            new RoomReservation(){}
        };


        public RoomServiceTest()
        {
            channelFactory = new ChannelFactory<IRoomService>(new BasicHttpBinding(), new EndpointAddress(roomUrl));
            roomClient = channelFactory.CreateChannel();     
        }

        [TestMethod]
        public void GetRooms()
        {
           var rooms =  roomClient.GetAll();
        }

        [TestMethod]
        public void GetRoom()
        {
            var room = roomClient.Get(2);
        }

        [TestMethod]
        public void ReserveRoom_Test()
        {
            //roomClient.Reserve();
        }

        [TestMethod]
        public void RejectRoom_Test()
        {
            //roomClient.Extend();
        }

        
    }
}
