using Microsoft.AspNetCore.Mvc;
using VideosWebsite.Models;
using VideosWebsite.Services.VideoAccess;

namespace VideosWebsite.Controllers;

public class VideosController : Controller
{
    //injections
    private IVideoAccess _videoaccess;

    public VideosController(IVideoAccess videoaccess)
    {
        _videoaccess = videoaccess;
    }
    
    //AUTOMATIC GET
    public IActionResult Index()
    {
        var videos = GetVideos();
        return View(videos);
    }
    
    
    // GET
    public IActionResult VideosPage()
    {
        return View("~/Views/Pages/VideosPage.cshtml");
    }
    
    public List<Video> GetVideos()
    {
        var videos = _videoaccess.GetVideos();
        return videos;
    }

    [HttpPost]
    public async Task<string> StoreVideo(IFormFile videofile)
    {
        if (videofile.Length == 0)
        {
            return "Video File is not accepted";
        }
        else
        {
            Video video = new Video();
            video.Title = videofile.FileName;
            
            return "Video uploaded successfully";
        }
        
        
        
    }


    
    
    
}