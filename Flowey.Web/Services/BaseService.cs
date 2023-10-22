using System.Net.Mime;
using System.Text;
using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Web.Models;
using Flowey.Web.Services.IServices;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;

namespace Flowey.Web.Services;

public class BaseService : IBaseService
{
    public BaseService(IHttpClientFactory httpClient)
    {
        HttpClient = httpClient;
        ResponseModel = new ResponseDto();
    }
    
    public void Dispose()
    {
    }

    public ResponseDto ResponseModel { get; set; }
    public IHttpClientFactory HttpClient { get; set; }
    
    public async Task<ResponseDto> SendAsync(ApiRequest apiRequest)
    {
        try
        {
            var client = HttpClient.CreateClient("FloweyAPI");
            var message = new HttpRequestMessage();
            message.Headers.Add(HeaderNames.Accept, MediaTypeNames.Application.Json);
            message.RequestUri = apiRequest.Uri;
            client.DefaultRequestHeaders.Clear();

            if (apiRequest.Data is not null)
            {
                message.Headers.Add(HeaderNames.ContentEncoding, "utf-8");
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8);
            }

            HttpResponseMessage? apiResponse = null;
            switch (apiRequest.ApiType)
            {
                case SD.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                
                case SD.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                
                case SD.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);
            string apiResponseContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiResponseContent);
            return apiResponseDto;
        }
        catch (Exception e)
        {
            var dto = new ResponseDto
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string> {e.Message},
                IsSuccess = false
            };

            return dto;
        }
    }
}