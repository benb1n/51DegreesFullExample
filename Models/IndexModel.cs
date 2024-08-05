using FiftyOne.DeviceDetection;
using FiftyOne.Pipeline.CloudRequestEngine.FlowElements;
using FiftyOne.Pipeline.Core.Data;

namespace _51DegreesFullExample;

public class IndexModel
{
  public string HardwareVendor { get; private set; }
  public string HardwareName { get; private set; }
  public string DeviceType { get; private set; }
  public string PlatformVendor { get; private set; }
  public string PlatformName { get; private set; }
  public string PlatformVersion { get; private set; }
  public string BrowserVendor { get; private set; }
  public string BrowserName { get; private set; }
  public string BrowserVersion { get; private set; }
  public string ScreenWidth { get; private set; }
  public string ScreenHeight { get; private set; }
  public string DeviceId { get; private set; }

  public IFlowData FlowData { get; private set; }

  public CloudRequestEngine Engine { get; private set; }

  public List<EvidenceModel> Evidence { get; private set; }

  public IHeaderDictionary ResponseHeaders { get; private set; }

  public IndexModel(IFlowData flowData, IHeaderDictionary responseHeaders)
  {
    FlowData = flowData;
    ResponseHeaders = responseHeaders;

    // Get the cloud engine
    Engine = FlowData.Pipeline.GetElement<CloudRequestEngine>();
    // Get the evidence that was used when performing device detection.
    Evidence = FlowData.GetEvidence().AsDictionary()
        .Select(e => new EvidenceModel()
        {
          Key = e.Key,
          Value = e.Value.ToString(),
          Used = Engine.EvidenceKeyFilter.Include(e.Key)
        })
        .ToList();

    // Get the results of device detection.
    var deviceData = FlowData.Get<IDeviceData>();
    // Use helper functions to get a human-readable string representation of various
    // property values. These helpers handle situations such as the property missing
    // due to using a lite data file or the property not having a value because device
    // detection didn't find a match.
    HardwareVendor = deviceData.TryGetValue(d => d.HardwareVendor.GetHumanReadable());
    HardwareName = deviceData.TryGetValue(d => d.HardwareName.GetHumanReadable());
    DeviceType = deviceData.TryGetValue(d => d.DeviceType.GetHumanReadable());
    PlatformVendor = deviceData.TryGetValue(d => d.PlatformVendor.GetHumanReadable());
    PlatformName = deviceData.TryGetValue(d => d.PlatformName.GetHumanReadable());
    PlatformVersion = deviceData.TryGetValue(d => d.PlatformVersion.GetHumanReadable());
    BrowserVendor = deviceData.TryGetValue(d => d.BrowserVendor.GetHumanReadable());
    BrowserName = deviceData.TryGetValue(d => d.BrowserName.GetHumanReadable());
    BrowserVersion = deviceData.TryGetValue(d => d.BrowserVersion.GetHumanReadable());
    ScreenWidth = deviceData.TryGetValue(d => d.ScreenPixelsWidth.GetHumanReadable());
    ScreenHeight = deviceData.TryGetValue(d => d.ScreenPixelsHeight.GetHumanReadable());
    DeviceId = deviceData.TryGetValue(d => d.DeviceId.GetHumanReadable());
  }
}