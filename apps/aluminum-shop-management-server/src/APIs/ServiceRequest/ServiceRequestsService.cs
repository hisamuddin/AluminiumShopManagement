using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class ServiceRequestsService : ServiceRequestsServiceBase
{
    public ServiceRequestsService(AluminumShopManagementDbContext context)
        : base(context) { }
}
