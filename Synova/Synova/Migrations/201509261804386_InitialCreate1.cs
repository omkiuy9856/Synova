namespace Synova.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Booking", name: "Customer_CustomerID", newName: "Customers_CustomerID");
            RenameIndex(table: "dbo.Booking", name: "IX_Customer_CustomerID", newName: "IX_Customers_CustomerID");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Booking", name: "IX_Customers_CustomerID", newName: "IX_Customer_CustomerID");
            RenameColumn(table: "dbo.Booking", name: "Customers_CustomerID", newName: "Customer_CustomerID");
        }
    }
}
