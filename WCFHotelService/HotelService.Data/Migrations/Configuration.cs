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
                new RoomType(){ Name = "Single", Cost = 20M},
                new RoomType(){ Name = "Double", Cost = 40M},
                new RoomType(){ Name = "Studia", Cost = 70M},
                new RoomType(){ Name = "King", Cost = 200M},
            };
            foreach (var roomType in roomTypes)
                context.RoomTypes.Add(roomType);
            context.SaveChanges();


            IEnumerable<Room> rooms = new List<Room>()
            {
                new Room(){ Number = "1", RoomType = roomTypes.ElementAt(0), IsReserved = true},
                new Room(){ Number = "2", RoomType = roomTypes.ElementAt(0), IsReserved = false},
                new Room(){ Number = "3", RoomType = roomTypes.ElementAt(3), IsReserved = true},
                new Room(){ Number = "4", RoomType = roomTypes.ElementAt(1), IsReserved = false},
                new Room(){ Number = "5", RoomType = roomTypes.ElementAt(2), IsReserved = false}
            };

            foreach(var room in rooms)
                context.Rooms.Add(room);
            context.SaveChanges();

            Hotel hotel = new Hotel() { Address = address, Rooms = rooms };

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

            //IEnumerable<RoomReservation> reservations = new List<RoomReservation>()
            //{
            //    new RoomReservation(){ Guest = guests.ElementAt(2), Room = rooms.ElementAt(3), Days = 3, ReservationStatus = RoomReservationStatus.Reserved },
            //    new RoomReservation(){ Guest = guests.ElementAt(1), Room = rooms.ElementAt(1), Days = 2, ReservationStatus = RoomReservationStatus.Reserved }
            //};

            //foreach (var reservation in reservations)
            //    context.RoomReservations.Add(reservation);
            //context.SaveChanges();
        }
    }
}
