using FiftyOne.DeviceDetection.Cloud.FlowElements;
using FiftyOne.DeviceDetection.Examples.Cloud.GettingStartedWeb;
using FiftyOne.DeviceDetection.Uach;
using FiftyOne.Pipeline.CloudRequestEngine.FlowElements;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Needed?
builder.Services.AddSingleton<UachJsConversionElementBuilder>();
builder.Services.AddSingleton<CloudRequestEngineBuilder>();
builder.Services.AddSingleton<DeviceDetectionCloudEngineBuilder>();

builder.Services.AddFiftyOne(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

    // This is only needed when running under an ASP.NET test server.
    app.UseMiddleware<UserAgentCorrectionMiddleware>();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseFiftyOne();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
