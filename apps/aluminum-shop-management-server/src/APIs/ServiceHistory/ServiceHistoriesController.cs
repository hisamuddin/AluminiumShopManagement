using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class ServiceHistoriesController : ServiceHistoriesControllerBase
{
    public ServiceHistoriesController(IServiceHistoriesService service)
        : base(service) { }
}
