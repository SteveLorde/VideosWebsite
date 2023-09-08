using Microsoft.AspNetCore.Mvc;
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
    
    public Task GetVideos()
    {
        var videos = _videoaccess.GetVideos();
        return videos;
    }


    
    
    
}