namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class cart : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CartItem",
                c => new
                    {
                        CartItemID = c.Guid(nullable: false),
                        FoodID = c.Int(nullable: false),
                        CartID = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                        Order_OrderID = c.Guid(),
                    })
                .PrimaryKey(t => t.CartItemID)
                .ForeignKey("dbo.Food", t => t.FoodID, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.Order_OrderID)
                .Index(t => t.FoodID)
                .Index(t => t.Order_OrderID);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 255),
                        LastName = c.String(nullable: false, maxLength: 255),
                        Address = c.String(nullable: false, maxLength: 255),
                        City = c.String(nullable: false, maxLength: 255),
                        PostalCode = c.String(nullable: false),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        Total = c.Decimal(nullable: false, precision: 18, scale: 2),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItem", "Order_OrderID", "dbo.Order");
            DropForeignKey("dbo.CartItem", "FoodID", "dbo.Food");
            DropIndex("dbo.CartItem", new[] { "Order_OrderID" });
            DropIndex("dbo.CartItem", new[] { "FoodID" });
            DropTable("dbo.Order");
            DropTable("dbo.CartItem");
        }
    }
}
