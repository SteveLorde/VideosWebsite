using VideosWebsite.Models;

namespace VideosStorage;

public interface IStorageAccess
{
    public Task ShowVideosFromStorage();
    public Task GetVideoFromStorage(int id);
    public Task StoreVideoInStorage(Video video);
    

}