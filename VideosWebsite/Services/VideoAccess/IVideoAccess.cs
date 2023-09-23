using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoAccess;

public interface IVideoAccess
{
    //Videos
    public string[] GetVideos();
    public string[] GetThumbnails();
    public Video? GetVideo(int id);
    public Task<string> UploadVideo(string videoname, string uploadername, IFormFile videofile);
    //GIFs
    public Task ShowGIFs();
    public Task GetGIF();
    public Task StoreGIF();
    
}