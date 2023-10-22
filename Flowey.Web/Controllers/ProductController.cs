using Flowey.DataLayer.Models.ProductAPI.V1;
using Flowey.Web.Services.IServices;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Flowey.Web.Controllers;

public class ProductController : Controller
{
    private readonly IProductService _productService;

    public ProductController(IProductService productService)
    {
        _productService = productService;
    }
    
    public async Task<IActionResult> Index()
    {
        var response = await _productService.GetAllProductsAsync();
        if (response.IsSuccess && response.Result is not null)
        {
            var productsList = JsonConvert.DeserializeObject<List<ProductDto>>(response.Result.ToString()!);
            return View(productsList);
        }

        return View();
    }

    public IActionResult Create()
    {
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return Json("");
    }
}