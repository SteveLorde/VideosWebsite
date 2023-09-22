namespace VideosWebsite.Services.UploadVideo;

public interface IUploadVideo
{ 
    public string UploadVideoFile(string videoname, string uploadername, IFormFile videofile);
}