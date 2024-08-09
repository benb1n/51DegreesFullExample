using FiftyOne.DeviceDetection;
using FiftyOne.Pipeline.CloudRequestEngine.FlowElements;
using FiftyOne.Pipeline.Core.Data;
using Microsoft.AspNetCore.Http;

namespace _51DegreesFullExample.Models;

public class IndexViewModel
{
  public IHeaderDictionary ResponseHeaders { get; private set; }

  public string CloudEndPoint { get; set; } = "https://cloud.51degrees.com";


  public IndexViewModel(IHeaderDictionary responseHeaders)
  {
    ResponseHeaders = responseHeaders;
  }
}