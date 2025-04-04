using System.Data.Entity;

namespace Terminarz.Model;
class AppDbContext : DbContext
{
    public DbSet<Event> Events { get; set; } = null!;
    public AppDbContext() : base("TerminarzDB") { }
}
