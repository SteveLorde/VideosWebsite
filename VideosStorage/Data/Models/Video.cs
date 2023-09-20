using System.Collections.ObjectModel;

namespace VideosWebsite.Models;

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string[] Tags { get; set; }
    public User UploadedBy { get; set; }
    public string thumbnailpath { get; set; }
    public string filePath { get; set; }

}