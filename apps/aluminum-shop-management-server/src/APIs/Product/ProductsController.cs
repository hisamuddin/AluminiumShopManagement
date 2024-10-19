using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class ProductsController : ProductsControllerBase
{
    public ProductsController(IProductsService service)
        : base(service) { }
}
