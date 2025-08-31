using GamersCommunity.Core.Services;
using Sample.Database.Context;
using Sample.Database.Models;

namespace Sample.Consumer.Services
{
    /// <summary>
    /// Specialized table service for handling <see cref="User"/> entities.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This service inherits from <see cref="GenericTableService{TContext, TEntity}"/>,
    /// binding it to the <see cref="SampleDbContext"/> database context and the <see cref="User"/> entity type.
    /// </para>
    /// <para>
    /// It exposes all generic CRUD operations (List, Get, Update, Delete, etc.) implemented
    /// in <see cref="GenericTableService{TContext, TEntity}"/>, while associating them with the logical table name <c>"Users"</c>.
    /// </para>
    /// </remarks>
    public class UsersService : GenericTableService<SampleDbContext, User>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersService"/> class.
        /// </summary>
        /// <param name="context">
        /// The database context used to access the <c>Users</c> table.
        /// Typically injected by dependency injection.
        /// </param>
        public UsersService(SampleDbContext context)
            : base(context, "Users")
        {
        }
    }
}
