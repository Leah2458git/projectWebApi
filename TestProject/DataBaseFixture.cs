using Microsoft.EntityFrameworkCore;
using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject
{
    public class DatabaseFixture : IDisposable
    {
        public Shop214928673Context Context { get; private set; }

        public DatabaseFixture()
        {
            // Set up the test database connection and initialize the context
            var options = new DbContextOptionsBuilder<Shop214928673Context>()
                .UseSqlServer("Server=srv2\\pupils;Database=Tests;Trusted_Connection=True;TrustServerCertificate=True")
                .Options;
            Context = new Shop214928673Context(options);
            Context.Database.EnsureCreated();// create the data base
        }

         public void Dispose()
        {
            // Clean up the test database after all tests are completed
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }
}
