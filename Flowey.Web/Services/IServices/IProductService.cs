﻿
using Flowey.DataLayer.Models.ProductAPI.V1;

namespace Flowey.Web.Services.IServices;

public interface IProductService : IBaseService
{
    Task<ResponseDto> GetAllProductsAsync();
    Task<ResponseDto> GetProductByIdAsync(int id);
    Task<ResponseDto> CreateProductAsync(ProductDto productDto);
    Task<ResponseDto> UpdateProductAsync(ProductDto productDto);
    Task<ResponseDto> DeleteProductAsync(int id);
}