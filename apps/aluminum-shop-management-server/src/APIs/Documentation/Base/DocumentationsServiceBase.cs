using AluminumShopManagement.APIs;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;

namespace AluminumShopManagement.APIs;

public abstract class DocumentationsServiceBase : IDocumentationsService
{
    protected readonly AluminumShopManagementDbContext _context;

    public DocumentationsServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }
}
