using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;
using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using FoodTruckAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace Tests
{

    public class UnitTest1
    {
        [Fact]
        public async Task MenuItemController_Get_GetsOneMenuItembyID()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            });

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            });

            context.SaveChanges();

            //ACT
            MenuItemController testcontroller = new MenuItemController(mocklog.Object, context);
            var result1 = await testcontroller.Get(1);
            var result = result1.Value;


            //ASSERT
            Assert.Equal("Test1", result.Name);
            Assert.Equal("Main", result.FoodType);
            Assert.Equal("Testing1", result.Description);


        }

        [Fact]
        public async Task MenuItemController_Get_GetsAllMenuItems()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            });

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            });

            context.SaveChanges();

            //ACT
            MenuItemController testcontroller = new MenuItemController(mocklog.Object, context);
            var result1 = await testcontroller.Get();
            var result = result1.Value;


            //ASSERT
            Assert.Equal(2, result.Count);
            Assert.Equal("Test1", result[0].Name);
            Assert.Equal("Main", result[0].FoodType);
            Assert.Equal("Testing1", result[0].Description);
            Assert.Equal("Test2", result[1].Name);
            Assert.Equal("Side", result[1].FoodType);
            Assert.Equal("Testing2", result[1].Description);


        }

        [Fact]
        public async Task MenuItemController_GetName_GetsOneMenuItembyName()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            });

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            });

            context.SaveChanges();

            //ACT
            MenuItemController testcontroller = new MenuItemController(mocklog.Object, context);
            var result1 = await testcontroller.GetName("Test2");
            var result = result1.Value;


            //ASSERT
            Assert.Equal("Test2", result.Name);
            Assert.Equal("Side", result.FoodType);
            Assert.Equal("Testing2", result.Description);


        }



        [Fact]
        public async Task MenuItemController_Post_PostsOneMenuItem()
        {
            //Arrange
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();
            var test = new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            };

            //ACT
            MenuItemController testcontroller = new MenuItemController(mocklog.Object, context);
            await testcontroller.Post(test);
            //Get method was tested in first Test now being used to retrieve content that Post method created
            var result1 = await testcontroller.Get(1);
            var result = result1.Value;

            //ASSERT
            Assert.Equal("Test1", result.Name);
            Assert.Equal("Main", result.FoodType);
            Assert.Equal("Testing1", result.Description);
        }

        [Fact]
        public async Task MenuItemController_Delete_DeletesOneMenuItemByID()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            });

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            });

            context.SaveChanges();

            //ACT
            MenuItemController testcontroller = new MenuItemController(mocklog.Object, context);
            await testcontroller.Delete(2);
            var result1 = await testcontroller.Get();
            var result = result1.Value;

            //ASSERT
            Assert.Equal(1, result.Count);
            Assert.Equal("Test1", result[0].Name);
            Assert.Equal("Main", result[0].FoodType);

        }


        [Fact]
        public async Task MenusController_Get_GetAllMenus()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.Menus.Add(new Menu
            {
                MenuID = 1,
                MenuName = "Test"
            });

            context.Menus.Add(new Menu
            {
                MenuID = 2,
                MenuName = "Test2"

            });

            context.SaveChanges();

            //ACT
            MenusController testcontroller = new MenusController(mocklog.Object, context);
            var result1 = await testcontroller.Get();
            var result = result1.Value;

            //ASSERT
            Assert.Equal(2, result.Count);
            Assert.Equal("Test", result[0].MenuName);
            Assert.Equal("Test2", result[1].MenuName);
        }

        [Fact]
        public async Task MenusController_Get_ListofMenuItemsInMenuByMenuID()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            List<MenuItemLink> testLink = new List<MenuItemLink>() {
            new MenuItemLink() { MenuItemLinkID = 1, MenuID = 1, MenuItemID = 1 },
            new MenuItemLink() { MenuItemLinkID = 2, MenuID = 1, MenuItemID = 2 } };

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            });

            context.MenuItems.Add(new MenuItem
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            });
            context.Menus.Add(new Menu
            {
                MenuID = 1,
                MenuName = "Test",
                Links = testLink
            });


            context.SaveChanges();

            //ACT
            MenusController testcontroller = new MenusController(mocklog.Object, context);
            var result1 = await testcontroller.Get(1);
            var result = result1.Value;

            //ASSERT
            Assert.Equal(2, result.Count);
            Assert.Equal("Test1", result[0].Name);
            Assert.Equal("Test2", result[1].Name);
            Assert.Equal(2.99M, result[0].Price);
            Assert.Equal(3.99M, result[1].Price);
        }
        [Fact]
        public async Task MenusController_Post_CreatesNewMenu()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            MenuItem menuItem2 = new MenuItem()
            {
                MenuItemID = 1,
                Name = "Test1",
                FoodType = "Main",
                Description = "Testing1",
                Price = 2.99M,
            };

            MenuItem menuItem1 = new MenuItem()
            {
                MenuItemID = 2,
                Name = "Test2",
                FoodType = "Side",
                Description = "Testing2",
                Price = 3.99M,
            };

            context.MenuItems.Add(menuItem1);
            context.MenuItems.Add(menuItem2);
            context.SaveChanges();

            List<MenuItem> actual = new List<MenuItem>() {
            { menuItem1},{ menuItem2}};

            //ACT
            MenusController testcontroller = new MenusController(mocklog.Object, context);
            var result1 = await testcontroller.Post(actual, "TestMenu");
            var result = result1.Value;
            //Post returns the Menu with an ID, Name, and list of MenuItemLinks
            //Using Get by ID was tested above to retrieve that list of MenuItems that were added
            var menuItemList1 = await testcontroller.Get(result.MenuID);
            var menuItemList = menuItemList1.Value;

            //ASSERT
            Assert.Equal(2, result.Links.Count);
            Assert.Equal(2, menuItemList.Count);
            Assert.Equal("Test1", menuItemList[0].Name);
            Assert.Equal("Test2", menuItemList[1].Name);
            Assert.Equal("Testing1", menuItemList[0].Description);
            Assert.Equal("Testing2", menuItemList[1].Description);
        }

        [Fact]
        public async Task MenusController_Delete_DeletesOneMenuByID()
        {
            Mock<ILogger<MenuItemController>> mocklog = new();
            var testing = new TestingDB();
            var context = testing.CreateContextForInMemory();

            context.Menus.Add(new Menu
            {
                MenuID = 1,
                MenuName = "Test"
            });

            context.Menus.Add(new Menu
            {
                MenuID = 2,
                MenuName = "Test2"

            });

            context.SaveChanges();

            //ACT
            MenusController testcontroller = new MenusController(mocklog.Object, context);
            await testcontroller.Delete(1);
            var result1 = await testcontroller.Get();
            var result = result1.Value;

            //ASSERT
            Assert.Equal(1, result.Count);
            Assert.Equal("Test2", result[0].MenuName);

        }



    }
}