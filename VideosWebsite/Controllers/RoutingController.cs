using Microsoft.AspNetCore.Mvc;

namespace VideosWebsite.Controllers;

public class RoutingController : Controller
{
    // GET
    public IActionResult Index()
    {
        return Ok();
    }


    
    public IActionResult SettingsPage()
    {
        return Ok();
    }
    
    public IActionResult LoginRegisterPage()
    {
        return View("~/Views/Pages/LoginRegisterPage.cshtml");
    }
    
}