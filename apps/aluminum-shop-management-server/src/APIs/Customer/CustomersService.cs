using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class CustomersService : CustomersServiceBase
{
    public CustomersService(AluminumShopManagementDbContext context)
        : base(context) { }
}
