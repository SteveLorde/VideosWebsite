using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using VideosStorage;
using VideosWebsite.Data;
using VideosWebsite.Services.UploadVideo;
using VideosWebsite.Services.VideoAccess;
using VideosWebsite.Services.VideoStream;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IStorageAccess,StorageAccess>();
builder.Services.AddScoped<IVideoAccess, VideoAccess>();
builder.Services.AddScoped<IVideoStream, VideoStream>();
builder.Services.AddScoped<IUploadVideo, UploadVideo>();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DataBaseConnectionString")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions {
    FileProvider =  new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"..\VideosStorage\Storage")),
    RequestPath = "/storage"
});

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();