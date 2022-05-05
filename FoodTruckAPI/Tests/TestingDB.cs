using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTruckAPI.ClassLibrary.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace Tests
{
    internal class TestingDB : IDisposable
    {

        #region IDisposable Support  
        private bool disposedValue = false; // To detect redundant calls  

        public FoodTruckContext CreateContextForInMemory()
        {
            var option = new DbContextOptionsBuilder<FoodTruckContext>().UseInMemoryDatabase(databaseName: "Test_Database").Options;

            var context = new FoodTruckContext(option);
            if (context != null)
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }

            return context;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
