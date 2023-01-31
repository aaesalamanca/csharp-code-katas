using Microsoft.EntityFrameworkCore;

namespace Kata07EFGetStarted;

internal class BloggingContext : DbContext
{
    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }

    public string DbPath { get; set; }

    public BloggingContext()
    {
        var folder = Environment.SpecialFolder.ApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "blogging.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        _ = optionsBuilder.UseSqlite($"Data Source={DbPath}");
}
