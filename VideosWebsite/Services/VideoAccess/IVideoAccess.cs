namespace VideosWebsite.Services.VideoAccess;

public interface IVideoAccess
{
    //Videos
    public Task ShowVideos();
    public Task GetVideo();
    public Task StoreVideo();
    //GIFs
    public Task ShowGIFs();
    public Task GetGIF();
    public Task StoreGIF();
    
}