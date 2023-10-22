

using Flowey.DataLayer.Models.ProductAPI.V1;

namespace Flowey.Services.ProductAPI.Repository;

public interface IProductRepository
{
    Task<IEnumerable<ProductDto>> GetProductsAsync();
    Task<ProductDto?> GetProductByIdAsync(int productId);
    Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto);
    Task<bool> DeleteProductAsync(int productId);
}