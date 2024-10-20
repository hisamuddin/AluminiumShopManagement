using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class PurchaseOrdersController : PurchaseOrdersControllerBase
{
    public PurchaseOrdersController(IPurchaseOrdersService service)
        : base(service) { }
}
