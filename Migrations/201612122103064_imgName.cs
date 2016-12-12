namespace GroceryStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgName : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Food", "ImgName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Food", "ImgName");
        }
    }
}
