using CSTemplate.Schemas;
using Microsoft.EntityFrameworkCore;

namespace CSTemplate.Data;

public class AppDbContext : DbContext
{
  public DbSet<UserSchema> Users { get; set; }

  public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
  {
  }

  protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
  {
    if (!optionsBuilder.IsConfigured)
    {
      optionsBuilder.UseNpgsql(DbSource.ConnectionString);
    }
  }
}
