using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FoodTruckAPI.ClassLibrary.DataAccess;
using FoodTruckAPI.ClassLibrary.Models;
using FoodTruckAPI.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async Task MenuItemController_GetAll_GetsAllMenuItems()
        {
            //ARRANGE
            Mock<ILogger<MenuItemController>> mocklog = new();

            var data = new List<MenuItem>
            {
                new MenuItem { MenuItemID = 1, Name ="test1", Description = "testing1", FoodType = "Side", Price = 2.5M },
                new MenuItem { MenuItemID = 2, Name ="test2", Description = "testing2", FoodType = "Drink", Price = 3.5M },
                new MenuItem { MenuItemID = 3, Name ="test3", Description = "testing3", FoodType = "Main", Price = 4.5M }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<MenuItem>>();
            mockSet.As<IQueryable<MenuItem>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<MenuItem>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<MenuItem>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<MenuItem>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            var mockFT = new Mock<FoodTruckContext>();
            mockFT.Setup(x => x.MenuItems).Returns(mockSet.Object);

            //ACT
            var test = new MenuItemController(mocklog.Object, mockFT.Object);
            var menuItems = await test.Get();

            //ASSERT
            Assert.AreEqual(3, menuItems.Count);
            Assert.AreEqual("test1", menuItems[0].Name);
            Assert.AreEqual("test2", menuItems[1].Name);
            Assert.AreEqual("test3", menuItems[2].Name);
        }
    }
}