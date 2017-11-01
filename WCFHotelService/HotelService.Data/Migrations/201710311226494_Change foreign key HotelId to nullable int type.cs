namespace HotelService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeforeignkeyHotelIdtonullableinttype : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            AlterColumn("dbo.Rooms", "HotelId", c => c.Int());
            CreateIndex("dbo.Rooms", "HotelId");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "HotelId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels");
            DropIndex("dbo.Rooms", new[] { "HotelId" });
            AlterColumn("dbo.Rooms", "HotelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rooms", "HotelId");
            AddForeignKey("dbo.Rooms", "HotelId", "dbo.Hotels", "HotelId", cascadeDelete: true);
        }
    }
}
