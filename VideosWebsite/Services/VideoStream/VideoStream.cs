using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VideosWebsite.Data;

namespace VideosWebsite.Services.VideoStream;

class VideoStream : IVideoStream
{
    private DataContext _db;
    private string storagepath = "/VideosStorage/Storage/Videos1";
    
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

    private FileStreamResult GetVideo(int id)
    {
        var video = _db.Videos.FirstOrDefault(x => x.Id == id);
        var videoname = video.Title;
        string filepath = Path.Combine(storagepath, videoname);

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