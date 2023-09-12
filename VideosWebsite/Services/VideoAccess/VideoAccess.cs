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
    public string[] GetVideos()
    {
        //1-get thumbnails
        //2-return thumbnails
        //DETECT FILES
            string[] videofiles =  Directory.GetFiles("../VideosStorage/Storage/Videos1");
            return videofiles;
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