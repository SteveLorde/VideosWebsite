using Microsoft.EntityFrameworkCore;
using VideosWebsite.Data;
using VideosWebsite.Models;

namespace VideosStorage;

public class StorageAccess : IStorageAccess
{
    private readonly DataContext _db;

    public StorageAccess(DataContext db)
    {
        _db = db;
    }
    public List<Video> GetVideosFromStorage()
    {
        var videos =  _db.Videos.ToList();
        return videos;
    }

    public async Task GetVideoFromStorage(int id)
    {
        
    }

    public async Task StoreVideoInStorage(Video video)
    {
        
    }
}