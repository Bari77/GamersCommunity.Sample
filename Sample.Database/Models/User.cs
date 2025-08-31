using GamersCommunity.Core.Database;

namespace Sample.Database.Models;

public partial class User : IKeyTable
{
    public int Id { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime ModificationDate { get; set; }

    public string Name { get; set; } = null!;
}
