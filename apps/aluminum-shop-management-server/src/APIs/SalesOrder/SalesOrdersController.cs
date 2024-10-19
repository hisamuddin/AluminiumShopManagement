using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class SalesOrdersController : SalesOrdersControllerBase
{
    public SalesOrdersController(ISalesOrdersService service)
        : base(service) { }
}
