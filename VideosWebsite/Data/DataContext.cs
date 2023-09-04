using Microsoft.EntityFrameworkCore;
using VideosWebsite.Models;

namespace VideosWebsite.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
            
    }
    
    //entites
    public DbSet<User> Users { get; set; }
    public DbSet<Video> Videos { get; set; }
    
    
    
    
    
}