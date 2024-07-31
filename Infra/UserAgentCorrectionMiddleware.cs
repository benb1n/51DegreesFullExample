namespace FiftyOne.DeviceDetection.Examples.Cloud.GettingStartedWeb
{
  public class UserAgentCorrectionMiddleware
  {
    private readonly RequestDelegate next;

    public UserAgentCorrectionMiddleware(RequestDelegate next)
    {
      this.next = next;
    }

    public async Task Invoke(HttpContext httpContext)
    {
      var val = httpContext.Request.Headers["User-Agent"];
      httpContext.Request.Headers.Remove("User-Agent");
      httpContext.Request.Headers["User-Agent"] =
          new Microsoft.Extensions.Primitives.StringValues(string.Join(" ", val));
      await this.next(httpContext);
    }
  }
}