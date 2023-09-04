namespace VideosWebsite.Models;

public class Video
{
    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime ReleasedDate { get; set; }
    public List<string> Tags { get; set; }

}