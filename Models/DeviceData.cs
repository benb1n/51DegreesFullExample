using System;
using System.Collections.Generic;

namespace _51DegreesFullExample.Models;

public class DeviceData
{

  #region === 51D Device Data ===

  public bool? IsMobile { get; set; }
  public bool? IsTablet { get; set; }
  public bool? IsSmartPhone { get; set; }
  public bool? HasTouchScreen { get; set; }
  public int? ScreenPixelsWidth { get; set; }
  public int? ScreenPixelsHeight { get; set; }

  public string HardwareVendor { get; set; }
  public string HardwareModel { get; set; }
  public HashSet<string> HardwareName { get; set; }
  public string HardwareFamily { get; set; }
  public string OEM { get; set; }
  public int? ReleaseYear { get; set; }
  public int? ReleaseAge { get; set; }
  public bool? HasCamera { get; set; }
  public string PriceBand { get; set; }
  public string DeviceType { get; set; }
  public string NativePlatform { get; set; }
  public List<string> NativeBrand { get; set; }
  public List<string> NativeDevice { get; set; }
  public List<string> NativeModel { get; set; }
  public List<string> NativeName { get; set; }

  #endregion


  #region === 51D OS Data ===

  public string PlatformVendor { get; set; }
  public string PlatformName { get; set; }
  public string PlatformVersion { get; set; }
  public int? PlatformReleaseYear { get; set; }
  public int? PlatformReleaseAge { get; set; }
  public int? PlatformDiscontinuedYear { get; set; }
  public int? PlatformDiscontinuedAge { get; set; }
  public int? PlatformRank { get; set; }

  #endregion


  #region === 51D Web Browser Data ===

  public string BrowserVendor { get; set; }
  public string BrowserName { get; set; }
  public string BrowserVersion { get; set; }
  public string BrowserFamily { get; set; }
  public int? BrowserReleaseYear { get; set; }
  public int? BrowserReleaseAge { get; set; }
  public int? BrowserDiscontinuedYear { get; set; }
  public int? BrowserDiscontinuedAge { get; set; }
  public bool? IsEmulatingDevice { get; set; }
  public bool? IsDataMinimising { get; set; }
  public int? ScreenPixelsWidthJavaScript { get; set; }
  public int? ScreenPixelsHeightJavaScript { get; set; }

  #endregion


  #region === 51D Metrics Data ===

  public string DeviceId { get; set; }

  #endregion


  #region === 51D Bots ===

  public bool? IsCrawler { get; set; }

  #endregion
}

