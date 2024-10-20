using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class ProductsService : ProductsServiceBase
{
    public ProductsService(AluminumShopManagementDbContext context)
        : base(context) { }
}
