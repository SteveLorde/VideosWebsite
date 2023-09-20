using Microsoft.AspNetCore.Mvc;

namespace VideosWebsite.Services.VideoStream;

public interface IVideoStream
{
    public Task<FileStreamResult> StreamVideo(int id);
    public FileStreamResult StreamVideoTest();
}