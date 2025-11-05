using Microsoft.EntityFrameworkCore;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests
{
    public class TestsDataFixture : IDisposable
    {
        /// <summary>
        /// Creates a new in-memory <see cref="SampleDbContext"/> with a unique database name.
        /// </summary>
        public SampleDbContext CreateContext()
        {
            var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new SampleDbContext(options);
        }

        /// <summary>
        /// Creates a fully functional <see cref="UsersService"/> with all required dependencies and seeded data.
        /// </summary>
        public UsersService CreateUsersService()
        {
            var ctx = CreateContext();
            SeedFullDataset(ctx);

            return new UsersService(ctx);
        }

        /// <summary>
        /// Seeds the full test dataset required across all services (relations, dependencies, etc.).
        /// </summary>
        public void SeedFullDataset(SampleDbContext ctx)
        {
            if (!ctx.Users.Any())
            {
                ctx.Users.AddRange(
                    new User { Id = 1, Name = "Jane Doe", CreationDate = DateTime.Now, ModificationDate = DateTime.Now },
                    new User { Id = 2, Name = "John Doe", CreationDate = DateTime.Now, ModificationDate = DateTime.Now }
                );
            }

            ctx.SaveChanges();
        }

        /// <summary>
        /// Called when test is ended
        /// </summary>
        public void Dispose()
        {
            // Clean
        }
    }
}
