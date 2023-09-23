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
    
    public IActionResult Index()
    {
        var thumbnails = _videoaccess.GetThumbnails();
        return View();
    }

    public IActionResult PlayVideo(int id)
    {
        var video = _videoaccess.GetVideo(id);
        return View("PlayVideo/PlayVideo", video);
    }

    public Task<FileStreamResult> StreamVideo(int id)
    {
        var videofile = _videostream.StreamVideo(id);
        return videofile;
    }


    [HttpPost]
    public async Task<string> UploadVideo(string videoname, string uploadername, IFormFile videofile)
    {
        try
        {
            
            return "Uploaded Successfully";
        }
        catch (Exception ex)
        {
            return "Upload Failed";
        }
        
    }


}