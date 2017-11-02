using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ServiceModel;
using HotelService.Contracts;

namespace WCFHotelService.Tests
{
    [TestClass]
    public class HotelServiceTest
    {
        private readonly string url = "http://localhost:52786/HotelService.svc";
        private readonly ChannelFactory<IHotelService> channelFactory;
        private readonly IHotelService client;

        public HotelServiceTest()
        {
            channelFactory = new ChannelFactory<IHotelService>(new BasicHttpBinding(), url);
            client = channelFactory.CreateChannel();
        }

        [TestMethod]
        public void GetHotelRooms_Test()
        {
            var rooms = client.GetHotelRooms("1");
        }

        [TestMethod]
        public void GetVacantRooms_Test()
        {
            var rooms = client.GetVacantRooms("1");
        }

        [TestMethod]
        public void GetReservedRooms_Test()
        {
           var rooms = client.GetReservedRooms("1");
           Assert.IsNotNull(rooms);
        }

        [TestMethod]
        public void GetRoomsByType_Test()
        {
            //var rooms = client.GetRoomsByType();
        }



    }
}
