using System.Collections;
using System.Collections.ObjectModel;

namespace VideosWebsite.Models;

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string[] Tags { get; set; }
    public string UploadedBy { get; set; }
    public string thumbnailpath { get; set; }
    public string filePath { get; set; }
    public int? Likes { get; set; }

}