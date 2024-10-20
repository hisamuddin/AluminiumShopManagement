using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class InvoicesService : InvoicesServiceBase
{
    public InvoicesService(AluminumShopManagementDbContext context)
        : base(context) { }
}
