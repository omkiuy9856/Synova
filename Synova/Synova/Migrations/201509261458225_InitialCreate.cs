namespace Synova.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Booking",
                c => new
                    {
                        BookingID = c.Int(nullable: false, identity: true),
                        BookingNo = c.Int(nullable: false),
                        Customer_Name = c.String(),
                        pickup_date = c.DateTime(nullable: false),
                        Customer_CustomerID = c.Int(),
                    })
                .PrimaryKey(t => t.BookingID)
                .ForeignKey("dbo.Customer", t => t.Customer_CustomerID)
                .Index(t => t.Customer_CustomerID);
            
            CreateTable(
                "dbo.Shipment",
                c => new
                    {
                        ShipmentID = c.Int(nullable: false, identity: true),
                        ShipmentNo = c.Int(nullable: false),
                        BookingNo = c.Int(nullable: false),
                        Customer_name = c.String(),
                        receiver_name = c.String(),
                        receiver_address = c.String(),
                        receiver_zipcode = c.Int(nullable: false),
                        receiver_tel = c.Int(nullable: false),
                        quantity = c.Int(nullable: false),
                        price = c.Decimal(precision: 18, scale: 2),
                        shipment_date = c.DateTime(),
                        pickup_date = c.DateTime(),
                        weight = c.Decimal(precision: 18, scale: 2),
                        Booking_BookingID = c.Int(),
                    })
                .PrimaryKey(t => t.ShipmentID)
                .ForeignKey("dbo.Booking", t => t.Booking_BookingID)
                .Index(t => t.Booking_BookingID);
            
            CreateTable(
                "dbo.DistributeCenter",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ShipmentID = c.Int(nullable: false),
                        user_name = c.String(),
                        driver_name = c.String(),
                        Driver_DriverId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Driver", t => t.Driver_DriverId)
                .ForeignKey("dbo.Shipment", t => t.ShipmentID, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_UserId)
                .Index(t => t.ShipmentID)
                .Index(t => t.Driver_DriverId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Driver",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        telephone = c.String(),
                        RouteID = c.String(),
                        car_id = c.String(),
                        Route_ID = c.Int(),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Route", t => t.Route_ID)
                .Index(t => t.Route_ID);
            
            CreateTable(
                "dbo.Route",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        area = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                        name = c.String(),
                        tel = c.Int(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        status_name = c.String(),
                        ShipmentID = c.Int(nullable: false),
                        time = c.Time(precision: 7),
                    })
                .PrimaryKey(t => t.StatusId)
                .ForeignKey("dbo.Shipment", t => t.ShipmentID, cascadeDelete: true)
                .Index(t => t.ShipmentID);
            
            CreateTable(
                "dbo.Customer",
                c => new
                    {
                        CustomerID = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        Tel = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Booking", "Customer_CustomerID", "dbo.Customer");
            DropForeignKey("dbo.Status", "ShipmentID", "dbo.Shipment");
            DropForeignKey("dbo.DistributeCenter", "User_UserId", "dbo.User");
            DropForeignKey("dbo.DistributeCenter", "ShipmentID", "dbo.Shipment");
            DropForeignKey("dbo.Driver", "Route_ID", "dbo.Route");
            DropForeignKey("dbo.DistributeCenter", "Driver_DriverId", "dbo.Driver");
            DropForeignKey("dbo.Shipment", "Booking_BookingID", "dbo.Booking");
            DropIndex("dbo.Status", new[] { "ShipmentID" });
            DropIndex("dbo.Driver", new[] { "Route_ID" });
            DropIndex("dbo.DistributeCenter", new[] { "User_UserId" });
            DropIndex("dbo.DistributeCenter", new[] { "Driver_DriverId" });
            DropIndex("dbo.DistributeCenter", new[] { "ShipmentID" });
            DropIndex("dbo.Shipment", new[] { "Booking_BookingID" });
            DropIndex("dbo.Booking", new[] { "Customer_CustomerID" });
            DropTable("dbo.Customer");
            DropTable("dbo.Status");
            DropTable("dbo.User");
            DropTable("dbo.Route");
            DropTable("dbo.Driver");
            DropTable("dbo.DistributeCenter");
            DropTable("dbo.Shipment");
            DropTable("dbo.Booking");
        }
    }
}
