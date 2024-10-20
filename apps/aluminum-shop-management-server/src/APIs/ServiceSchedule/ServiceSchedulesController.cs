using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class ServiceSchedulesController : ServiceSchedulesControllerBase
{
    public ServiceSchedulesController(IServiceSchedulesService service)
        : base(service) { }
}
