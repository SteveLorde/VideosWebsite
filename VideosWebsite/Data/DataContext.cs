using Microsoft.EntityFrameworkCore;
using VideosWebsite.Models;

namespace VideosWebsite.Data;

public class DataContext : DbContext
{
    //entites
    public DbSet<User> Users { get; set; }
    public DbSet<Video> Videos { get; set; }
    
    
    
    
    
}