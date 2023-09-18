using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoAccess;

public interface IVideoAccess
{
    //Videos
    public string[] GetVideos();
    public string[] GetThumbnails();
    public Task GetVideo(int id);
    public Task<string> StoreVideo(IFormFile videofile);
    //GIFs
    public Task ShowGIFs();
    public Task GetGIF();
    public Task StoreGIF();
    
}