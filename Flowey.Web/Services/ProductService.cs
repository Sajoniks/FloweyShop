using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Web.Models;
using Flowey.Web.Services.IServices;

namespace Flowey.Web.Services;

public class ProductService : BaseService, IProductService
{
    public ProductService(IHttpClientFactory httpClient) : base(httpClient)
    {
    }

    public Task<ResponseDto> GetAllProductsAsync()
    {
        return SendAsync(new ApiRequest(new Uri($"{SD.ProductAPIBase}/api/products"))
        {
            ApiType = SD.ApiType.GET,
            AccessToken = ""
        });
    }

    public Task<ResponseDto> GetProductByIdAsync(int id)
    {
        var uriBuilder = new UriBuilder(SD.ProductAPIBase)
        {
            Path = $"/api/products/{id}"
        };

        return SendAsync(new ApiRequest(uriBuilder.Uri)
        {
            ApiType = SD.ApiType.GET,
            AccessToken = ""
        });
    }

    public Task<ResponseDto> CreateProductAsync(ProductDto productDto)
    {
        return SendAsync(new ApiRequest(new Uri($"{SD.ProductAPIBase}/api/products"))
        {
            ApiType = SD.ApiType.POST,
            Data = productDto,
            AccessToken = ""
        });
    }

    public Task<ResponseDto> UpdateProductAsync(ProductDto productDto)
    {
        return SendAsync(new ApiRequest(new Uri($"{SD.ProductAPIBase}/api/products"))
        {
            ApiType = SD.ApiType.PUT,
            AccessToken = ""
        });   
    }

    public Task<ResponseDto> DeleteProductAsync(int id)
    {
        var uriBuilder = new UriBuilder(SD.ProductAPIBase)
        {
            Path = $"api/products/{id}"
        };
        return SendAsync(new ApiRequest(uriBuilder.Uri)
        {
            ApiType = SD.ApiType.DELETE,
            AccessToken = ""
        });
    }
}