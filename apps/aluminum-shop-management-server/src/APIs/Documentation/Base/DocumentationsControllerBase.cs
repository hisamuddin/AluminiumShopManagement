using AluminumShopManagement.APIs;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class DocumentationsControllerBase : ControllerBase
{
    protected readonly IDocumentationsService _service;

    public DocumentationsControllerBase(IDocumentationsService service)
    {
        _service = service;
    }
}
