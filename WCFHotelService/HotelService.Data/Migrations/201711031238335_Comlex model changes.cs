namespace HotelService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Comlexmodelchanges : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Discounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        GuestType = c.Int(nullable: false),
                        Rate = c.Double(nullable: false),
                        Hotel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Hotels", t => t.Hotel_Id)
                .Index(t => t.Hotel_Id);
            
            AddColumn("dbo.RoomReservations", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            DropColumn("dbo.RoomReservations", "Days");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomReservations", "Days", c => c.Int(nullable: false));
            DropForeignKey("dbo.Discounts", "Hotel_Id", "dbo.Hotels");
            DropIndex("dbo.Discounts", new[] { "Hotel_Id" });
            DropColumn("dbo.RoomReservations", "Price");
            DropTable("dbo.Discounts");
        }
    }
}
