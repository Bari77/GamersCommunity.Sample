using GamersCommunity.Core.Services;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Consumer.Services.Data
{
    /// <summary>
    /// Specialized data service for handling <see cref="User"/> entities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service inherits from <see cref="GenericDataService{TContext, TEntity}"/>,
    /// binding it to the <see cref="SampleDbContext"/> database context and the <see cref="User"/> entity type.
    /// </para>
    /// <para>
    /// It exposes all generic CRUD operations (List, Get, Update, Delete, etc.) implemented
    /// in <see cref="GenericDataService{TContext, TEntity}"/>, while associating them with the logical table name <c>"Users"</c>.
    /// </para>
    /// </remarks>
    /// <param name="context">
    /// The database context used to access the <c>Users</c> table.
    /// Typically injected by dependency injection.
    /// </param>
    public class UsersService(SampleDbContext context) : GenericDataService<SampleDbContext, User>(context, "Users")
    {
    }
}
