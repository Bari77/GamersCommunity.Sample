using GamersCommunity.Core.Tests;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests.Services.Data
{
    public class UsersTests : GenericServiceTests<SampleDbContext, UsersService, User>, IClassFixture<TestsFixture>
    {
        public UsersTests(TestsFixture fixture) : base(fixture._usersService)
        {
            fixture._testDbContext.AddRange(GetFakeData());
            fixture._testDbContext.SaveChanges();
        }

        protected override List<User> GetFakeData()
        {
            return
            [
                new() {
                    Id = 1,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Name = "Jane Doe",
                },
                new() {
                    Id = 2,
                    CreationDate = DateTime.Now,
                    ModificationDate = DateTime.Now,
                    Name = "John Doe",
                },
            ];
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
