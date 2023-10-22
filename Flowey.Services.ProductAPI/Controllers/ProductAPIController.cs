using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Services.ProductAPI.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Flowey.Services.ProductAPI.Controllers;

[Route("api/products")]
public class ProductAPIController : ControllerBase
{
    protected ResponseDto _response;
    private IProductRepository _productProductRepository;

    public ProductAPIController(IProductRepository productRepository)
    {
        _productProductRepository = productRepository;
        _response = new ResponseDto();
    }

    [HttpGet]
    public async Task<object> Get()
    {
        try
        {
            IEnumerable<ProductDto> productDtos = await _productProductRepository.GetProductsAsync();
            _response.Result = productDtos;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() }; 
        }

        return _response;
    }
    
    [HttpGet]
    [Route("{id}")]
    public async Task<object> Get(int id)
    {
        try
        {
            ProductDto? productDto = await _productProductRepository.GetProductByIdAsync(id);
            _response.Result = productDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() }; 
        }

        return _response;
    }

    [HttpPost]
    public async Task<object> Post([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto myProductDto = await _productProductRepository.CreateUpdateProductAsync(productDto);
            _response.Result = myProductDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() }; 
        }

        return _response;
    }

    [HttpPut]
    public async Task<object> Put([FromBody] ProductDto productDto)
    {
        try
        {
            ProductDto myProductDto = await _productProductRepository.CreateUpdateProductAsync(productDto);
            _response.Result = myProductDto;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() }; 
        }

        return _response;
    }
    
    [HttpDelete]
    public async Task<object> Delete(int id)
    {
        try
        {
            bool isSuccess = await _productProductRepository.DeleteProductAsync(id);
            _response.Result = isSuccess;
        }
        catch (Exception ex)
        {
            _response.IsSuccess = false;
            _response.ErrorMessages = new List<string>() { ex.ToString() }; 
        }

        return _response;
    }
}