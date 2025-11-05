using GamersCommunity.Core.Tests;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests.Services.Data
{
    public class UsersTests(TestsDataFixture fixture) : GenericDataServiceTests<SampleDbContext, UsersService, User>, IClassFixture<TestsDataFixture>
    {
        protected override UsersService CreateService() => fixture.CreateUsersService();

        protected override List<User> GetFakeData()
        {
            return [];
        }

        protected override User GetNewEntity()
        {
            return new User
            {
                Name = "New user"
            };
        }
    }
}
