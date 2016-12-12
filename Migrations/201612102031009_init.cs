namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FoodGroup",
                c => new
                    {
                        FoodGroupID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.FoodGroupID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.FoodGroup");
        }
    }
}
