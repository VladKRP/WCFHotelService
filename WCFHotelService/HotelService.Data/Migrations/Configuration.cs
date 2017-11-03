namespace HotelService.Data.Migrations
{
    using HotelService.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<HotelService.Data.HotelAppContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HotelService.Data.HotelAppContext context)
        {
            Address address = new Address() { City = "Moscow", Street = "Kalinina 20", PostalCode = "43433" };
            context.Addresses.Add(address);

            IEnumerable<RoomType> roomTypes = new List<RoomType>()
            {
                new RoomType(){ Name = "Single"},
                new RoomType(){ Name = "Double"},
                new RoomType(){ Name = "Studia"},
                new RoomType(){ Name = "King"},
            };
            foreach (var Type in roomTypes)
                context.RoomTypes.Add(Type);
            context.SaveChanges();


            List<Room> rooms = new List<Room>()
            {
                new Room(){ Number = "1", Type = roomTypes.ElementAt(0), Cost = 40M,  IsReserved = true},
                new Room(){ Number = "2", Type = roomTypes.ElementAt(0), Cost = 40M,  IsReserved = false},
                new Room(){ Number = "3", Type = roomTypes.ElementAt(3), Cost = 260M,  IsReserved = true},
                new Room(){ Number = "4", Type = roomTypes.ElementAt(1), Cost = 60M,  IsReserved = false},
                new Room(){ Number = "5", Type = roomTypes.ElementAt(2), Cost = 90M,  IsReserved = false}
            };

            foreach(var room in rooms)
                context.Rooms.Add(room);
            context.SaveChanges();

            Hotel hotel = new Hotel() { Address = address, Rooms = rooms, Name = "Dolphin" };

            context.Hotels.Add(hotel);
            context.SaveChanges();

            IEnumerable<Guest> guests = new List<Guest>()
            {
                new Guest(){ Name = "Petr", Surname = " Ivanov", PassportNumber = "ms32324234234"},
                new Guest(){ Name = "Lidia", Surname = "Pavlova", PassportNumber = "342423ee4wq234"},
                new Guest(){ Name = "Ivan", Surname = " Koren'", PassportNumber = "qs34asd33232"}
            };

            foreach (var guest in guests)
                context.Guests.Add(guest);
            context.SaveChanges();

            IEnumerable<RoomReservation> reservations = new List<RoomReservation>()
            {
                new RoomReservation(){ Guest = guests.ElementAt(2), Room = rooms.ElementAt(3), Price = 12m, ReservationStatus = RoomReservationStatus.Reserved , BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(3) },
                new RoomReservation(){ Guest = guests.ElementAt(1), Room = rooms.ElementAt(1), Price = 30m, ReservationStatus = RoomReservationStatus.Reserved , BeginDate = DateTime.Now, EndDate = DateTime.Now.AddDays(2) }
            };

            foreach (var reservation in reservations)
                context.RoomReservations.Add(reservation);
            context.SaveChanges();
        }
    }
}
