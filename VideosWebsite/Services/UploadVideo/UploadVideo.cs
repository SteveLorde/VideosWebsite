using System.Diagnostics;
using VideosWebsite.Data;
using VideosWebsite.Models;

namespace VideosWebsite.Services.UploadVideo;

class UploadVideo : IUploadVideo
{
    private string storagepath = Path.Combine(Directory.GetCurrentDirectory() + @"..\VideosStorage\Storage\Videos");
    private IWebHostEnvironment _webhost;
    private DataContext _db;
    public UploadVideo(IWebHostEnvironment webhost, DataContext db)
    {
        _webhost = webhost;
        _db = db;
    }
    public string UploadVideoFile(string videoname, string uploadername, IFormFile videofile)
    {
        //1-convert video
        bool checkconversion = ConvertVideo(videoname, videofile);
        //2-return success message
        if (checkconversion)
        {
            return "Video Uploaded Successfully";
        }
        else
        {
            return "ERROR Video Not Saved/Converted";
        }
    }

    private bool ConvertVideo(string videoname, IFormFile videofile)
    {
        string ffmpegpath = Path.Combine(_webhost.WebRootPath, "..", "Services", "UploadVideo", "ffmpeg", "ffmpeg.exe");
        
        //1-take inpu file and output to webm
        string inputpath = Path.Combine(_webhost.WebRootPath, "VideosStorage", "Videos", videofile.FileName);
        var outputfilename = videoname + ".webm";
        string outputpath = Path.Combine(_webhost.WebRootPath, "VideosStorage", "Videos", outputfilename);
        
        
        //2-webm conversion process
        
        //GENERATE THUMBNAIL FOR VIDEO
        
        
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = ffmpegpath,
                Arguments = $"-i {inputpath} -c:v libvpx -crf 10 -b:v 1M -c:a libvorbis {outputpath}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        process.WaitForExit();
        
        //4-return TRUE if output file exists
        if (File.Exists(outputpath))
        {
            return true;
        }
        else
        {
            return false;
        }

    }

    private bool RegisterNewVideo(string videoname, string uploadername, string convertedvideopath)
    {
        //1-initialize new Video model object
        Video newvideo = new Video();
        //TEST SAVING
        newvideo.UploadedBy = "UploaderTest";
        newvideo.Title = videoname;
        newvideo.filePath = convertedvideopath;
        _db.Videos.AddAsync(newvideo);
        //production UPLOADERNAME
        
        //2-return True
        bool newvideoexists = _db.Videos.Any(x => x.Title == videoname);
        if (newvideoexists)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    
}


/*
//2-convert video file to webm

//3-rename and copy video file to storage
var newvideopath = Path.Combine(storagepath, videofile.FileName);
var storagestream = new FileStream(newvideopath, FileMode.Create);
videofile.CopyToAsync(storagestream);
//4-convert and register new video in Database
*/



