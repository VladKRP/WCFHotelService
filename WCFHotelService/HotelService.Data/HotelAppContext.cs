using HotelService.Domain;
using System.Data.Entity;


namespace HotelService.Data
{
    public class HotelAppContext : DbContext
    {
        public HotelAppContext():base("HotelServiceContext") { }

        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<RoomReservation> RoomReservations { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<GuestStatistic> GuestStatistic { get; set; }

    }
}
