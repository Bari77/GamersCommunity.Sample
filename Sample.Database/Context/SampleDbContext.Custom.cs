using Microsoft.EntityFrameworkCore;

namespace Sample.Database.Context
{
    /// <summary>
    /// Partial definition of the application's Entity Framework Core database context.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This partial class supplements the <c>SampleDbContext</c> definition, providing
    /// a default configuration for connecting to SQL Server when no other configuration
    /// has been applied (e.g., during design-time migrations).
    /// </para>
    /// <para>
    /// The connection string is resolved by name from the application's configuration:
    /// <c>ConnectionStrings:Database</c>.
    /// </para>
    /// </remarks>
    public partial class SampleDbContext
    {
        /// <summary>
        /// Configures the database context with default options if none have been set.
        /// </summary>
        /// <param name="optionsBuilder">
        /// The builder used to configure database options for this context.
        /// </param>
        /// <remarks>
        /// <para>
        /// If the options have not been configured externally (for example, through dependency
        /// injection in <c>Program.cs</c>), this method will configure EF Core to use SQL Server
        /// with the connection string name <c>"ConnectionStrings:Database"</c>.
        /// </para>
        /// <para>
        /// This ensures design-time tools such as <c>dotnet ef migrations</c> can function even
        /// outside of the normal hosting environment.
        /// </para>
        /// </remarks>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Database");
            }
        }
    }
}
