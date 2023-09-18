using Microsoft.AspNetCore.Mvc.Rendering;

namespace VideosWebsite.Services.HTML_Helpers.GetFileName;

public static class HtmlHelperExtensions
{
    public static string GetFileName(this IHtmlHelper htmlHelper, string filePath)
    {
        return Path.GetFileName(filePath);
    }
}