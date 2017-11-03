using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.ServiceModel;
using HotelService.Contracts;
using HotelService.Domain;
using HotelService.Data.Abstractions;
using Moq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace WCFHotelService.Tests
{
    [TestClass]
    public class RoomServiceTest
    {
        private readonly string roomUrl = "http://localhost:52786/RoomService.svc";
        private readonly ChannelFactory<IRoomService> channelFactory;
        private readonly IRoomService client;
        private Mock<IRoomRepository> mock;
        private IRoomRepository repository;
        private List<Room> rooms = new List<Room>()
        {
            new Room(){Id = 1, Number = "15",  HotelId = 1, IsReserved = true, Cost = 20m},
            new Room(){Id = 2, Number = "5A",  HotelId = 1, IsReserved = false, Cost = 30m},
            new Room(){Id = 3, Number = "14",  HotelId = 2, IsReserved = false, Cost = 20m},
            new Room(){Id = 4, Number = "4",  HotelId = 2, IsReserved = true, Cost = 60m},
            new Room(){Id = 5, Number = "1",  HotelId = 2, IsReserved = false, Cost = 20m}
        };  

        private Mock<Repository> MockSetups<Repository,Entity>(List<Entity> data)
            where Repository : class , IRoomRepository
            where Entity : Room 
        {
            Mock<Repository> mock = new Mock<Repository>();
            mock.Setup(x => x.GetAll()).Returns(data);
            mock.Setup(x => x.Get(It.IsAny<int>())).Returns((int id) => data.Where(x => x.Id.Equals(id)).SingleOrDefault());
            mock.Setup(x => x.Create(It.IsAny<Room>())).Callback((Entity room) => data.Add(room));
            //mock.Setup(x => x.Update());
            mock.Setup(x => x.Delete(It.IsAny<Room>())).Callback((Entity room) => data.Remove(room));
            return mock;
        }


        public RoomServiceTest()
        {
            channelFactory = new ChannelFactory<IRoomService>(new BasicHttpBinding(), new EndpointAddress(roomUrl));
            client = channelFactory.CreateChannel();
            mock = MockSetups<IRoomRepository, Room>(rooms);
            repository = mock.Object;
        }

        [TestMethod]
        public void GetAllRooms_CanReturnRooms()
        {
            var result = repository.GetAll();
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result.Count());
        }

        [TestMethod]
        public void GetRoom_ReturnExpectedRoom()
        {
            var room = repository.Get(2);
            var notExistingRoom = repository.Get(12);
            Assert.IsNotNull(room);
            Assert.IsNull(notExistingRoom); 
            Assert.AreEqual(rooms.ElementAt(1), room);
            Assert.AreNotEqual(new Room() { Id = 2, Number = "5A", HotelId = 2, IsReserved = false, Cost = 30m }, room);
        }    

        [TestMethod]
        public void CreateRoom_CanCreateTest()
        {
            var room = new Room(){ Id = 12, HotelId = 2, Number = "102A", IsReserved = false, Cost = 35m };
            Assert.IsTrue(repository.GetAll().Count().Equals(5));
            repository.Create(room);
            Assert.IsTrue(repository.GetAll().Count().Equals(6));
            Assert.IsNotNull(repository.Get(12));
            Assert.AreEqual(room.Number, repository.Get(12).Number);
        }

        [TestMethod]
        public void DeleteRoom_CanDeleteTest()
        {
            var rooms = repository.GetAll();
            var roomsCount = rooms.Count();
            var expectedRoomsCount = 5;
            Assert.IsTrue(roomsCount.Equals(expectedRoomsCount), $"Expected number of room {expectedRoomsCount} but actual number is {roomsCount}");
            Assert.IsNotNull(repository.Get(rooms.ElementAt(4).Id));

            repository.Delete(rooms.ElementAt(4));
            expectedRoomsCount--;
            roomsCount = repository.GetAll().Count();

            Assert.IsTrue(roomsCount.Equals(expectedRoomsCount), $"Expected number of room {expectedRoomsCount} but actual number is {roomsCount}");
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => repository.Get(rooms.ElementAt(4).Id));
        }

    }
}
