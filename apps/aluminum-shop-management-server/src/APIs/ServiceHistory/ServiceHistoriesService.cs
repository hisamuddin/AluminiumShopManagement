using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class ServiceHistoriesService : ServiceHistoriesServiceBase
{
    public ServiceHistoriesService(AluminumShopManagementDbContext context)
        : base(context) { }
}
