using Microsoft.AspNetCore.Mvc;
using VideosWebsite.Models;
using VideosWebsite.Services.VideoAccess;
using VideosWebsite.Services.VideoStream;

namespace VideosWebsite.Controllers;

public class VideosController : Controller
{
    //injections
    private IVideoAccess _videoaccess;
    private IVideoStream _videostream;

    public VideosController(IVideoAccess videoaccess, IVideoStream videostream)
    {
        _videoaccess = videoaccess;
        _videostream = videostream;
    }
    
    //AUTOMATIC GET
    public IActionResult Index()
    {
        //var videos = _videoaccess.GetVideos();
        var thumbnails = _videoaccess.GetThumbnails();
        ViewData["thumbnailfiles"] = thumbnails;
        return View();
    }
    
    
    // GET
    public IActionResult VideosPage()
    {
        return View("~/Views/Pages/VideosPage.cshtml");
    }

    public IActionResult PlayVideo(int id)
    {
        var video = _videostream.StreamVideo(id);
        return View("PlayVideo/PlayVideo", video);
    }
    


    [HttpPost]
    public async Task<string> StoreVideo(IFormFile videofile)
    {
        try
        {
            string path = Path.Combine("VideosStorage/Storage/Videos1");
            return "Uploaded Successfully";
        }
        catch (Exception ex)
        {
            return "Failed";
        }
        
    }


    
    
    
}