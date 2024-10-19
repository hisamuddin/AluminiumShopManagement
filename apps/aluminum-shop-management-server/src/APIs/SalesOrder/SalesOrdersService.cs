using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class SalesOrdersService : SalesOrdersServiceBase
{
    public SalesOrdersService(AluminumShopManagementDbContext context)
        : base(context) { }
}
