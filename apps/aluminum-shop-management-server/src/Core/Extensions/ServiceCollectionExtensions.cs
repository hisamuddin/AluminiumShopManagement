using AluminumShopManagement.APIs;

namespace AluminumShopManagement;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
        services.AddScoped<IDocumentationsService, DocumentationsService>();
        services.AddScoped<IInvoicesService, InvoicesService>();
        services.AddScoped<IPaymentsService, PaymentsService>();
        services.AddScoped<IProductsService, ProductsService>();
        services.AddScoped<IPurchaseOrdersService, PurchaseOrdersService>();
        services.AddScoped<ISalesOrdersService, SalesOrdersService>();
        services.AddScoped<IServiceHistoriesService, ServiceHistoriesService>();
        services.AddScoped<IServiceRequestsService, ServiceRequestsService>();
        services.AddScoped<IServiceSchedulesService, ServiceSchedulesService>();
        services.AddScoped<ISuppliersService, SuppliersService>();
    }
}
