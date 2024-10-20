using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class InvoicesController : InvoicesControllerBase
{
    public InvoicesController(IInvoicesService service)
        : base(service) { }
}
