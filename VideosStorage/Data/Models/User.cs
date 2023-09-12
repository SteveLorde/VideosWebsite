using System.Collections.ObjectModel;

namespace VideosWebsite.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string HashedPassword { get; set; }
    
}