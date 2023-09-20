using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VideosWebsite.Data;
using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoStream;

class VideoStream : IVideoStream
{
    private DataContext _db;
    private string storagepath1 = Path.Combine(Directory.GetCurrentDirectory(), @"..\VideosStorage\Storage\Videos");
    private string storagepath2 = @"..\VideosStorage\Storage\Videos";
    public VideoStream(DataContext db)
    {
        _db = db;
    }
    
    
    public async Task<FileStreamResult> StreamVideo(int id)
    {
        var videofile = GetVideo(id);
        if (videofile != null)
        {
            return videofile;
        }
        else
        {
            return null;
        }
    }

    public FileStreamResult StreamVideoTest()
    {
        string videotestpath = Path.Combine(storagepath2, "Video1.mp4");
        if (!System.IO.File.Exists(videotestpath))
        {
            throw new FileNotFoundException("The specified video file was not found.");
        }
        var videoteststream = new FileStream(videotestpath, FileMode.Open, FileAccess.Read, FileShare.Read);
        return new FileStreamResult(videoteststream, "video/mp4");
    }

    private FileStreamResult? GetVideo(int id)
    {
        Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
        string filepath = Path.Combine(storagepath1, video.Title);
        if (File.Exists(filepath))
        {
            var fileStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
            return new FileStreamResult(fileStream, "video/mp4");
        }
        else
        {
            return null;
        }
    }
    
}