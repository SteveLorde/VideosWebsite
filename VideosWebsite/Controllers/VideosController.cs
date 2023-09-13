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
        var videos = _videoaccess.GetVideos();
        return View(videos);
    }
    
    
    // GET
    public IActionResult VideosPage()
    {
        return View("~/Views/Pages/VideosPage.cshtml");
    }

    public IActionResult PlayVideo(int id)
    {
        //1-search for file using id
        
        //2-get file to play
        
        //3-return file and route to PlayVideo player view
        return View("PlayVideo/PlayVideo");
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