using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using HotelService.Contracts;

namespace WCFHotelService.Tests
{
    [TestClass]
    public class RoomReservationServiceTest
    {
        private readonly string url = "http://localhost:52786/RoomReservationService.svc";
        private readonly ChannelFactory<IRoomReservationService> channelFactory;
        private readonly IRoomReservationService client;

        public RoomReservationServiceTest()
        {
            channelFactory = new ChannelFactory<IRoomReservationService>(new BasicHttpBinding(), url);
            client = channelFactory.CreateChannel();
        }


       
    }
}
