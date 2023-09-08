using Microsoft.EntityFrameworkCore;
using VideosWebsite.Models;

namespace VideosWebsite.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Video>().Property(e => e.Tags).HasConversion(x => string.Join(',', x),
            v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));
    }

    //entites
    public DbSet<User> Users { get; set; }
    public DbSet<Video> Videos { get; set; }
    
    
    
    
    
}