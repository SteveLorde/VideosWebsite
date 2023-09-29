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

    public List<Video> GetThumbnails()
    {
        List<Video> videosdata = _db.Videos.ToList();
        return videosdata;
    }

    public Video GetVideoData(int id)
    {
        Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
        return video;
    }

    //GIF
    //---------------------------------------------------
        
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