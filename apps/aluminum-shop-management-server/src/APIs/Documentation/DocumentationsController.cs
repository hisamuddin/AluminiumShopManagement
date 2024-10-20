using AluminumShopManagement.APIs;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

[ApiController()]
public class DocumentationsController : DocumentationsControllerBase
{
    public DocumentationsController(IDocumentationsService service)
        : base(service) { }
}
