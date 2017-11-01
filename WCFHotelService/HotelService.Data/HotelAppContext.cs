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

        public void FixEfProviderServicesProblem()
        {
            //The Entity Framework provider type 'System.Data.Entity.SqlServer.SqlProviderServices, EntityFramework.SqlServer'
            //for the 'System.Data.SqlClient' ADO.NET provider could not be loaded. 
            //Make sure the provider assembly is available to the running application. 
            //See http://go.microsoft.com/fwlink/?LinkId=260882 for more information.

            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
