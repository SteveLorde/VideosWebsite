using VideosStorage;
using VideosWebsite.Models;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

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
            string[] videofiles =  Directory.GetFiles("/VideosStorage/Storage/Videos1");
            return videofiles;
    }

    public string[] GetThumbnails()
    {
        string thumbnailPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\VideosStorage\Storage\Thumbnails");
        string[] thumbnails = Directory.GetFiles(thumbnailPath);
        return thumbnails;
    }

    public Task GetVideo(int id)
    {
        var video = _storageaccess.GetVideoFromStorage(id);
        return video;
    }

        
        public async Task<string> StoreVideo(IFormFile videofile)
    {
        //1-receive video file
        if (videofile.Length == 0)
        {
            return "Video saving error";
        }
        else
        {
            return "lol";
            //2-generate thumbnail (with same name) and save it
            //3-save video(physical) on storage
        }
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