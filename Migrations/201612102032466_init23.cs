namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Food",
                c => new
                    {
                        FoodID = c.Int(nullable: false, identity: true),
                        VendorID = c.Int(nullable: false),
                        FoodGroupID = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Description = c.String(),
                        Weight = c.Double(nullable: false),
                        ExpiryDate = c.DateTime(nullable: false),
                        Stock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FoodID)
                .ForeignKey("dbo.FoodGroup", t => t.FoodGroupID, cascadeDelete: true)
                .ForeignKey("dbo.Vendor", t => t.VendorID, cascadeDelete: true)
                .Index(t => t.VendorID)
                .Index(t => t.FoodGroupID);
            
            CreateTable(
                "dbo.Vendor",
                c => new
                    {
                        VendorID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Description = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.VendorID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Food", "VendorID", "dbo.Vendor");
            DropForeignKey("dbo.Food", "FoodGroupID", "dbo.FoodGroup");
            DropIndex("dbo.Food", new[] { "FoodGroupID" });
            DropIndex("dbo.Food", new[] { "VendorID" });
            DropTable("dbo.Vendor");
            DropTable("dbo.Food");
        }
    }
}
