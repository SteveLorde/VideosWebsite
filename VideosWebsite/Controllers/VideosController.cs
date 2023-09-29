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
        List<Video> videosdata = _videoaccess.GetThumbnails();
        return View(videosdata);
    }

    public IActionResult PlayVideo(int id)
    {
        Video video = _videoaccess.GetVideoData(id);
        return View("PlayVideo/PlayVideo", video);
    }

    public IResult StreamVideo(int id)
    {
        return _videostream.StreamVideo(id);
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