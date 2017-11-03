namespace HotelService.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletecostfromRoomType : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.RoomTypes", "Cost");
        }
        
        public override void Down()
        {
            AddColumn("dbo.RoomTypes", "Cost", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
