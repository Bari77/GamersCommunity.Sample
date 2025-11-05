using Microsoft.EntityFrameworkCore;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;

namespace Sample.Tests
{
    public class TestsFixture : IDisposable
    {
        #region Global

        /// <summary>
        /// Testing database context
        /// </summary>
        public readonly SampleDbContext _testDbContext;

        #region Implementations

        #region Countries

        /// <summary>
        /// Implementation for users
        /// </summary>
        public readonly UsersService _usersService;

        #endregion

        #endregion

        #endregion

        /// <summary>
        /// Called when tests start
        /// /!\ CARE: This context is shared between tests /!\
        /// </summary>
        public TestsFixture()
        {
            var options = new DbContextOptionsBuilder<SampleDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            _testDbContext = new SampleDbContext(options);

            // Init all implementations
            _usersService = new UsersService(_testDbContext);
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
