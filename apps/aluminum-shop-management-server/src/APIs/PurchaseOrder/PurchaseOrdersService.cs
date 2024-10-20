using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class PurchaseOrdersService : PurchaseOrdersServiceBase
{
    public PurchaseOrdersService(AluminumShopManagementDbContext context)
        : base(context) { }
}
