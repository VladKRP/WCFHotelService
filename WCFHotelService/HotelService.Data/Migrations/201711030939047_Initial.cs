namespace HotelService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        City = c.String(),
                        Street = c.String(),
                        PostalCode = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Guests",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Surname = c.String(),
                        Type = c.Int(nullable: false),
                        PassportNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GuestStatistics",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        ReservationCount = c.Int(nullable: false),
                        RentDaysAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .Index(t => t.GuestId);
            
            CreateTable(
                "dbo.Hotels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Number = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsReserved = c.Boolean(nullable: false),
                        HotelId = c.Int(),
                        Type_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.HotelId)
                .ForeignKey("dbo.RoomTypes", t => t.Type_Id)
                .Index(t => t.HotelId)
                .Index(t => t.Type_Id);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Cost = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoomReservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestId = c.Int(nullable: false),
                        RoomId = c.Int(nullable: false),
                        BeginDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Days = c.Int(nullable: false),
                        ReservationStatus = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Guests", t => t.GuestId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.GuestId)
                .Index(t => t.RoomId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomReservations", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomReservations", "GuestId", "dbo.Guests");
            DropForeignKey("dbo.Rooms", "Type_Id", "dbo.RoomTypes");
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropForeignKey("dbo.Hotels", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.GuestStatistics", "GuestId", "dbo.Guests");
            DropIndex("dbo.RoomReservations", new[] { "RoomId" });
            DropIndex("dbo.RoomReservations", new[] { "GuestId" });
            DropIndex("dbo.Rooms", new[] { "Type_Id" });
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            DropIndex("dbo.Hotels", new[] { "Address_Id" });
            DropIndex("dbo.GuestStatistics", new[] { "GuestId" });
            DropTable("dbo.RoomReservations");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.Rooms");
            DropTable("dbo.Hotels");
            DropTable("dbo.GuestStatistics");
            DropTable("dbo.Guests");
            DropTable("dbo.Addresses");
        }
    }
}
