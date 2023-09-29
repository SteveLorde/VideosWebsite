﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using VideosWebsite.Data;
using VideosWebsite.Models;

namespace VideosWebsite.Services.VideoStream;

class VideoStream : IVideoStream
{
    private DataContext _db;
    private IWebHostEnvironment _hostenv;
    public VideoStream(DataContext db, IWebHostEnvironment hostenv)
    {
        _db = db;
        _hostenv = hostenv;
    }
    
    
    public IResult StreamVideo(int id)
    {
        return GetVideo(id);
    }


    private IResult GetVideo(int id)
    {
        Video video = _db.Videos.FirstOrDefault(x => x.Id == id);
        string filepath = $@"..{video.filePath}";
        if (File.Exists(filepath))
        {
            var videofile = System.IO.File.OpenRead(filepath);
            return Results.File(videofile);
        }
        else
        {
            throw new Exception($"Videofile NOT FOUND at {filepath}");
        }
    }
    
}