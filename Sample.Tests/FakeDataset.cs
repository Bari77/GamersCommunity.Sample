using GamersCommunity.Core.Tests;
using Microsoft.EntityFrameworkCore;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests
{
    /// <summary>
    /// Get a Fake dataset
    /// </summary>
    public class FakeDataset : IFakeDataset<SampleDbContext>
    {
        /// <summary>
        /// Creates a new in-memory <see cref="SampleDbContext"/> with a unique database name and fill with basic fake data.
        /// </summary>
        public SampleDbContext CreateFakeContext() => SeedFakeData(new SampleDbContext(
            new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options
            ));

        /// <summary>
        /// Seeds the full test dataset required across all services (relations, dependencies, etc.).
        /// </summary>
        private SampleDbContext SeedFakeData(SampleDbContext ctx)
        {
            ctx.ChangeTracker.AutoDetectChangesEnabled = false;

            #region Users

            ctx.Users.AddRange(
                new User
                {
                    Id = 1,
                    Name = "User A",
                    CreationDate = DateTime.UtcNow,
                    ModificationDate = DateTime.UtcNow,
                },
                new User
                {
                    Id = 2,
                    Name = "User B",
                    CreationDate = DateTime.UtcNow,
                    ModificationDate = DateTime.UtcNow,
                }
            );

            #endregion

            ctx.ChangeTracker.AutoDetectChangesEnabled = true;

            ctx.SaveChanges();

            return ctx;
        }
    }
}
