using AluminumShopManagement.Infrastructure.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.Infrastructure;

public class AluminumShopManagementDbContext : IdentityDbContext<IdentityUser>
{
    public AluminumShopManagementDbContext(
        DbContextOptions<AluminumShopManagementDbContext> options
    )
        : base(options) { }

    public DbSet<ProductDbModel> Products { get; set; }

    public DbSet<SupplierDbModel> Suppliers { get; set; }

    public DbSet<PurchaseOrderDbModel> PurchaseOrders { get; set; }

    public DbSet<ServiceRequestDbModel> ServiceRequests { get; set; }

    public DbSet<InvoiceDbModel> Invoices { get; set; }

    public DbSet<ServiceScheduleDbModel> ServiceSchedules { get; set; }

    public DbSet<CustomerDbModel> Customers { get; set; }

    public DbSet<SalesOrderDbModel> SalesOrders { get; set; }

    public DbSet<PaymentDbModel> Payments { get; set; }

    public DbSet<ServiceHistoryDbModel> ServiceHistories { get; set; }
}
