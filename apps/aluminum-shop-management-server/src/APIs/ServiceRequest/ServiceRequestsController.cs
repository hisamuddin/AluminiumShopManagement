using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class ServiceRequestsController : ServiceRequestsControllerBase
{
    public ServiceRequestsController(IServiceRequestsService service)
        : base(service) { }
}
