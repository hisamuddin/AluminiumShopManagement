using AluminumShopManagement.Infrastructure;

namespace AluminumShopManagement.APIs;

public class PaymentsService : PaymentsServiceBase
{
    public PaymentsService(AluminumShopManagementDbContext context)
        : base(context) { }
}
