using GamersCommunity.Core.Tests;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests.Services.Data
{
    public class UsersTests(TestsDataFixture fixture) : GenericDataServiceTests<SampleDbContext, UsersService, User>, IClassFixture<TestsDataFixture>
    {
        protected override UsersService CreateService()
        {
            var ctx = fixture.CreateContext();
            ctx.Users.AddRange(GetFakeData());
            ctx.SaveChanges();

            fixture.SeedFullDataset(ctx);

            return new UsersService(ctx);
        }

        protected override List<User> GetFakeData()
        {
            return [];
        }

        protected override User GetNewEntity() => new()
        {
            Name = "New user",
            CreationDate = DateTime.Now,
            ModificationDate = DateTime.Now,
        };
    }
}
