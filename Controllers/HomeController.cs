using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiftyOne.Pipeline.Web.Services;
using _51DegreesFullExample.Models;
using Newtonsoft.Json;

namespace _51DegreesFullExample.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IFlowDataProvider _provider;

    public HomeController(IFlowDataProvider provider, ILogger<HomeController> logger)
    {
        _provider = provider;
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new IndexViewModel(Response.Headers));
    }

    [HttpPost("devicedetectioncallback")]
    public async Task<IActionResult> DeviceCheckCallBack([FromBody] string postback)
    {
        var deviceDetectionDto = JsonConvert.DeserializeObject<DeviceDetectionDto>(postback.ToString());

        var deviceData = JsonConvert.DeserializeObject<DeviceData>(deviceDetectionDto.SerializedDeviceData);

        // === temp ===
        _logger.LogInformation("51D client-side serialized data: {@SerializedDeviceData}", deviceDetectionDto.SerializedDeviceData);
        _logger.LogInformation("51D client-side data: {@DeviceData}", JsonConvert.SerializeObject(deviceData));
        // === temp ===

        return Ok("/Home/Complete");
    }

    public IActionResult Complete()
    {
        // Use the provider to get the flow data. This contains the results of device
        // detection that has been performed by the pipeline.
        return View(new CompleteViewModel(_provider.GetFlowData(), Response.Headers));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
