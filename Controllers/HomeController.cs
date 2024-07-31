using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FiftyOne.Pipeline.Web.Services;
using _51Degrees1.Models;

namespace _51Degrees1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IFlowDataProvider _provider;

        // The controller has a dependency on IFlowDataProvider. This is used to access the 
        // IFlowData that contains the device detection results for the current HTTP request.
        public HomeController(IFlowDataProvider provider, ILogger<HomeController> logger)
        {
            _provider = provider;
            _logger = logger;
        }

    public IActionResult Index()
    {
        // Use the provider to get the flow data. This contains the results of device
        // detection that has been performed by the pipeline.
        return View(new IndexModel(_provider.GetFlowData(), Response.Headers));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
