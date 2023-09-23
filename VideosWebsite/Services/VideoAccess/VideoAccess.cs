using VideosStorage;
using VideosWebsite.Data;
using VideosWebsite.Models;
using VideosWebsite.Services.UploadVideo;
using IFormFile = Microsoft.AspNetCore.Http.IFormFile;

namespace VideosWebsite.Services.VideoAccess;

class VideoAccess : IVideoAccess
{
    //Variables and Injections

    private IStorageAccess _storageaccess;
    private IUploadVideo _uploadservice;
    private DataContext _db;
    

    public VideoAccess(IStorageAccess storageaccess, IUploadVideo uploadservice, DataContext db)
    {
        _storageaccess = storageaccess;
        _uploadservice = uploadservice;
        _db = db;
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
        Console.Write(thumbnails);
        return thumbnails;
    }

    public Video GetVideo(int id)
    {
        Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
        return video;
    }

        
        public async Task<string> UploadVideo(string videoname, string uploadername, IFormFile videofile)
    {
        //1-receive video file
        if (videofile.Length == 0)
        {
            return "Video saving error";
        }
        else
        {
            //_uploadservice.UploadVideoFile(videoname, uploadername, videofile);
            return "lol";
            //2-generate thumbnail (with same name) and save it
            //3-save video(physical) on storage
        }
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