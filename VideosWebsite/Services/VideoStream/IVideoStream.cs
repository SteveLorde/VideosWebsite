using Microsoft.AspNetCore.Mvc;

namespace VideosWebsite.Services.VideoStream;

public interface IVideoStream
{
    public IResult StreamVideo(int id);
    //public IResult StreamVideoTest();
}