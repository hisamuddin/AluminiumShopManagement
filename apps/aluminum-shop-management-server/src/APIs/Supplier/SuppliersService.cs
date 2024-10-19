using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class SuppliersService : SuppliersServiceBase
{
    public SuppliersService(AluminumShopManagementDbContext context)
        : base(context) { }
}
