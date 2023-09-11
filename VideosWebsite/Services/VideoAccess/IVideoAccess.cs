using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoAccess;

public interface IVideoAccess
{
    //Videos
    public List<Video> GetVideos();
    public Task GetVideo(int id);
    public Task StoreVideo();
    //GIFs
    public Task ShowGIFs();
    public Task GetGIF();
    public Task StoreGIF();
    
}