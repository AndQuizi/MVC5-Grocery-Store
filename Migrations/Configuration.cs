namespace GroceryStore.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<GroceryStore.DAL.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(GroceryStore.DAL.StoreContext context)
        {

            var foodGroups = new List<FoodGroup>
            {
                new FoodGroup
                {
                    Name = "Vegetables"
                },
                new FoodGroup
                {
                    Name = "Fruits"
                },
                new FoodGroup
                {
                    Name = "Meats"
                },
                new FoodGroup
                {
                    Name = "Dairy"
                },
                new FoodGroup
                {
                    Name = "Grains"
                },
            };

            foodGroups.ForEach(s => context.FoodGroups.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var vendors = new List<Vendor>
            {
                new Vendor
                {
                    Name = "Andrews Baked Goods",
                    Description = "Baked Daily. Always Fresh.",
                    Address = "1234 Industrial Way"
                },
                new Vendor
                {
                    Name = "Grandams Kitchen",
                    Description = "I dont even get paid for this.",
                    Address = "74 Old Folks Home"
                },
                new Vendor
                {
                    Name = "Cosco",
                    Description = "We're right down the street.",
                    Address = "1239 Industrial Way"
                }
            };

            vendors.ForEach(s => context.Vendors.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var foods = new List<Food>
            {
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Fruits" ).FoodGroupID,
                    Name = "Apple",
                    Price = 0.75m,
                    Description = "Tastes alright",
                    Weight = 0.25,
                    ExpiryDate = DateTime.Parse("2017-01-01"),
                    Stock = 100,
                    ImgName = "apple.png"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Fruits" ).FoodGroupID,
                    Name = "Blueberries",
                    Price = 3.99m,
                    Description = "Picked by hard working (compensated) children",
                    Weight = 2.08,
                    ExpiryDate = DateTime.Parse("2017-01-30"),
                    Stock = 40,
                    ImgName = "blueberries.png"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Vegetables" ).FoodGroupID,
                    Name = "Broccoli",
                    Price = 3.99m,
                    Weight = 1.76,
                    ExpiryDate = DateTime.Parse("2016-12-25"),
                    Stock = 22,
                    ImgName = "broccoli.png"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Vegetables" ).FoodGroupID,
                    Name = "Peas",
                    Price = 4.99m,
                    Description = "Better then grandmas!",
                    Weight = 1.99,
                    ExpiryDate = DateTime.Parse("2017-01-25"),
                    Stock = 30,
                    ImgName = "peas.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Meats" ).FoodGroupID,
                    Name = "Pork Chop",
                    Price = 7.25m,
                    Description = "Should have no worms",
                    Weight = 1.35,
                    ExpiryDate = DateTime.Parse("2016-12-20"),
                    Stock = 15,
                    ImgName = "porkCop.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Meats" ).FoodGroupID,
                    Name = "Ham",
                    Price = 8.50m,
                    Weight = 2.1,
                    ExpiryDate = DateTime.Parse("2016-12-20"),
                    Stock = 12,
                    ImgName = "ham.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Meats" ).FoodGroupID,
                    Name = "Salmon",
                    Price = 6.25m,
                    Description = "Fresh from the Salmon farm",
                    Weight = 1.85,
                    ExpiryDate = DateTime.Parse("2016-12-25"),
                    Stock = 8,
                    ImgName = "salmon.jpg"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Meats" ).FoodGroupID,
                    Name = "Shrimp",
                    Price = 8.99m,
                    Description = "They aight",
                    Weight = 1.42,
                    ExpiryDate = DateTime.Parse("2016-12-16"),
                    Stock = 14,
                    ImgName = "shrimp.jpg"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Dairy" ).FoodGroupID,
                    Name = "Butter",
                    Price = 3.99m,
                    Description = "I can't believe its actually butter!",
                    Weight = 0.60,
                    ExpiryDate = DateTime.Parse("2016-12-30"),
                    Stock = 20,
                    ImgName = "butter.jpg"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Dairy" ).FoodGroupID,
                    Name = "Cheese",
                    Price = 9.99m,
                    Description = "Who doesn't love cheese",
                    Weight = 0.80,
                    ExpiryDate = DateTime.Parse("2016-12-30"),
                    Stock = 30,
                    ImgName = "cheese.jpg"
                },
                 new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Cosco" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Dairy" ).FoodGroupID,
                    Name = "Milk",
                    Price = 4.99m,
                    Weight = 1.2,
                    ExpiryDate = DateTime.Parse("2016-12-30"),
                    Stock = 25,
                    ImgName = "milk.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Andrews Baked Goods" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Grains" ).FoodGroupID,
                    Name = "Bread",
                    Price = 3,
                    Description = "Baked today, yesterday, or last week",
                    Weight = 1.02,
                    ExpiryDate = DateTime.Parse("2016-12-15"),
                    Stock = 20,
                    ImgName = "bread.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Andrews Baked Goods" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Grains" ).FoodGroupID,
                    Name = "Blueberry Muffins",
                    Price = 4,
                    Description = "Freshly picked blueberries",
                    Weight = 0.83,
                    ExpiryDate = DateTime.Parse("2016-12-28"),
                    Stock = 10,
                    ImgName = "butter.jpg"
                },

                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Andrews Baked Goods" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Grains" ).FoodGroupID,
                    Name = "Pumpkin Bread",
                    Price = 9.35m,
                    Weight = 1.33,
                    ExpiryDate = DateTime.Parse("2016-12-25"),
                    Stock = 12,
                    ImgName = "blueMuffin.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Grandams Kitchen" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Grains" ).FoodGroupID,
                    Name = "Apple Pie",
                    Price = 10.25m,
                    Description = "Aww yeaahh",
                    Weight = 2.32,
                    ExpiryDate = DateTime.Parse("2016-12-31"),
                    Stock = 8,
                    ImgName = "appPie.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Grandams Kitchen" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Vegetables" ).FoodGroupID,
                    Name = "Tomatoe",
                    Price = 0.75m,
                    Description = "Garden grown",
                    Weight = 0.32,
                    ExpiryDate = DateTime.Parse("2016-12-15"),
                    Stock = 30,
                    ImgName = "tomatoe.jpg"
                },
                new Food
                {
                    VendorID = vendors.Single(c => c.Name == "Grandams Kitchen" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Vegetables" ).FoodGroupID,
                    Name = "Cucumber",
                    Price = 1.25m,
                    Description = "Garden grown",
                    Weight = 0.62,
                    ExpiryDate = DateTime.Parse("2016-12-20"),
                    Stock = 20,
                    ImgName = "cucumbers.jpg"
                },
                new Food
                {

                    VendorID = vendors.Single(c => c.Name == "Grandams Kitchen" ).VendorID,
                    FoodGroupID = foodGroups.Single(c => c.Name == "Vegetables" ).FoodGroupID,
                    Name = "Peas",
                    Price = 2.99m,
                    Description = "Garden grown",
                    Weight = 1.99,
                    ExpiryDate = DateTime.Parse("2016-12-25"),
                    Stock = 16,
                    ImgName = "peas.jpg"
                }
            };

            foods.ForEach(s => context.Foods.AddOrUpdate(p => new { p.Name, p.VendorID }, s));
            context.SaveChanges();

        }
    }
}
