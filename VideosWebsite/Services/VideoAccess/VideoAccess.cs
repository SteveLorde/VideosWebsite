using VideosStorage;
using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoAccess;

class VideoAccess : IVideoAccess
{
    //Variables and Injections

    private IStorageAccess _storageaccess;
    

    public VideoAccess(IStorageAccess storageaccess)
    {
        _storageaccess = storageaccess;
    }
    
    
    //Methods
    //-------
    public List<Video> GetVideos()
    {
        var videos = _storageaccess.GetVideosFromStorage();
        return videos;
    }

    public Task GetVideo(int id)
    {
        var video = _storageaccess.GetVideoFromStorage(id);
        return video;
    }

    public async Task StoreVideo()
    {
        
    }

    public async Task StoreVideo(Video video)
    {
        _storageaccess.StoreVideoInStorage(video);
    }

    public async Task ShowGIFs()
    {
        
    }

    public async Task GetGIF()
    {
        
    }

    public async Task StoreGIF()
    {
        
    }
}