using GamersCommunity.Core.Tests;
using Sample.Consumer.Services.Data;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Tests.Services.Data
{
    public class UsersServiceTests : GenericDataServiceTests<SampleDbContext, UsersService, User>
    {
        protected override List<User> GetFakeData() => [];

        protected override User GetNewEntity() => new()
        {
            Name = "New user",
            CreationDate = DateTime.UtcNow,
            ModificationDate = DateTime.UtcNow,
        };

        protected override UsersService CreateService() => new(CreateContext());
    }
}
