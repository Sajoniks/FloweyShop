namespace Flowey.Web.Models;

public class ApiRequest
{
    public ApiRequest(Uri uri)
    {
        Uri = uri;
    }
    
    public SD.ApiType ApiType { get; set; } = SD.ApiType.GET;
    public Uri Uri { get; set; }
    public object? Data { get; set; }
    public string AccessToken { get; set; } = "";
}