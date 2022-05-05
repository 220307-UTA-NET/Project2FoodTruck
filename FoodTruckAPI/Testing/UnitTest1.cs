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

namespace Testing
{

    public class UnitTest1
    {
        [Fact]
        public async Task MenuItemController_GetAll_GetsAllMenuItems()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();
            var options = new DbContextOptionsBuilder<FoodTruckContext>()
            .UseInMemoryDatabase(databaseName: "FoodTruckTestDataBase")
            .Options;

            using (var context = new FoodTruckContext(options))
            {
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
               
                    MenuItemController controller = new MenuItemController(mocklog.Object, context);
                    var result = await controller.Get();
                    var actualResult = result.Value;

                //ASSERT
                    Assert.Equal(2, actualResult.Count);
                    Assert.Equal("Test1", actualResult[0].Name);
                    Assert.Equal("Main", actualResult[0].FoodType);
                    Assert.Equal("Testing1", actualResult[0].Description);
                
            }




        }
    }
}