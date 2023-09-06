using Microsoft.AspNetCore.Mvc;

namespace VideosWebsite.Controllers;

public class VideosController : Controller
{
    // GET
    public IActionResult VideosPage()
    {
        return View("~/Views/Pages/VideosPage.cshtml");
    }
    
    public IActionResult GetVideos()
    {
        return Ok();
    }


    
    
    
}