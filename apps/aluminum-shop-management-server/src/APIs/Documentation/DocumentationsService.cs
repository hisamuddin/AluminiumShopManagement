using AluminumShopManagement.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace AluminumShopManagement.APIs;

public class DocumentationsService : DocumentationsServiceBase
{
    public DocumentationsService(AluminumShopManagementDbContext context)
        : base(context) { }
}
