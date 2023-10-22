using AutoMapper;
using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Services.ProductAPI.DbContexts;
using Flowey.Services.ProductAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Flowey.Services.ProductAPI.Repository;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _db;
    private IMapper _mapper;

    public ProductRepository(ApplicationDbContext db, IMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<ProductDto>> GetProductsAsync()
    {
        List<Product> productList = await _db.Products.ToListAsync();
        return _mapper.Map<List<ProductDto>>(productList);
    }

    public async Task<ProductDto?> GetProductByIdAsync(int productId)
    {
        Product? product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
        if (product is not null)
        {
            return _mapper.Map<ProductDto>(product);
        }

        return null;
    }

    public async Task<ProductDto> CreateUpdateProductAsync(ProductDto productDto)
    {
        Product product = _mapper.Map<Product>(productDto);
        if (product.ProductId > 0)
        {
            _db.Products.Update(product);
        }
        else
        {
            _db.Products.Add(product);
        }

        await _db.SaveChangesAsync();
        return _mapper.Map<ProductDto>(product);
    }

    public async Task<bool> DeleteProductAsync(int productId)
    {
        try
        {
            Product? product = await _db.Products.Where(x => x.ProductId == productId).FirstOrDefaultAsync();
            if (product is not null)
            {
                _db.Products.Remove(product);
                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }
}