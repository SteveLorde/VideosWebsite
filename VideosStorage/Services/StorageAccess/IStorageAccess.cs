using VideosWebsite.Models;

namespace VideosStorage;

public interface IStorageAccess
{
    public List<Video> GetVideosFromStorage();
    public Task GetVideoFromStorage(int id);
    public Task StoreVideoInStorage(Video video);
    

}