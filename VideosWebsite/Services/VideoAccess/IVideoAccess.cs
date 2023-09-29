using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoAccess;

public interface IVideoAccess
{
    //Videos
    public List<Video> GetThumbnails();

    public Video GetVideoData(int id);
    //GIFs
    public Task ShowGIFs();
    public Task GetGIF();
    public Task StoreGIF();
    
}