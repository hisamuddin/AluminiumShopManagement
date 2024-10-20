using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class ServiceSchedulesService : ServiceSchedulesServiceBase
{
    public ServiceSchedulesService(AluminumShopManagementDbContext context)
        : base(context) { }
}
