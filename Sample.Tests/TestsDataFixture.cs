using Microsoft.EntityFrameworkCore;
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
        /// Seeds the full test dataset required across all services (relations, dependencies, etc.).
        /// </summary>
        public void SeedFullDataset(SampleDbContext ctx)
        {
            if (!ctx.Users.Any())
            {
                ctx.Users.AddRange(
                    new User
                    {
                        Name = "User A",
                        CreationDate = DateTime.Now,
                        ModificationDate = DateTime.Now
                    },
                    new User
                    {
                        Name = "User B",
                        CreationDate = DateTime.Now,
                        ModificationDate = DateTime.Now
                    }
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
