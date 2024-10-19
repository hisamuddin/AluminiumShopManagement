using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class SuppliersController : SuppliersControllerBase
{
    public SuppliersController(ISuppliersService service)
        : base(service) { }
}
