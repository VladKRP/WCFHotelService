namespace HotelService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Changes1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.GuestStatistics",
                c => new
                    {
                        GuestStatisticId = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        ReservationCount = c.Int(nullable: false),
                        RentDaysAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GuestStatisticId)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.GuestStatistics", "GuestId", "dbo.Guests");
            DropIndex("dbo.GuestStatistics", new[] { "GuestId" });
            DropTable("dbo.GuestStatistics");
        }
    }
}
