using System.Diagnostics;

namespace VideosWebsite.Services.UploadVideo;

class UploadVideo : IUploadVideo
{
    private string storagepath = Path.Combine(Directory.GetCurrentDirectory() + @"..\VideosStorage\Storage\Videos");
    private IWebHostEnvironment _webhost;
    public UploadVideo(IWebHostEnvironment webhost)
    {
        _webhost = webhost;
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
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = ffmpegpath,
                Arguments = $"-i {inputpath} {outputpath}",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            }
        };
        process.Start();
        process.WaitForExit();
        
        //3-return TRUE if output file exists
        if (File.Exists(outputpath))
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



