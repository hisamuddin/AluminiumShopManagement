using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;

namespace AluminumShopManagement.APIs;

public interface ISalesOrdersService
{
    /// <summary>
    /// Create one SalesOrder
    /// </summary>
    public Task<SalesOrder> CreateSalesOrder(SalesOrderCreateInput salesorder);

    /// <summary>
    /// Delete one SalesOrder
    /// </summary>
    public Task DeleteSalesOrder(SalesOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many SalesOrders
    /// </summary>
    public Task<List<SalesOrder>> SalesOrders(SalesOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about SalesOrder records
    /// </summary>
    public Task<MetadataDto> SalesOrdersMeta(SalesOrderFindManyArgs findManyArgs);

    /// <summary>
    /// Get one SalesOrder
    /// </summary>
    public Task<SalesOrder> SalesOrder(SalesOrderWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one SalesOrder
    /// </summary>
    public Task UpdateSalesOrder(
        SalesOrderWhereUniqueInput uniqueId,
        SalesOrderUpdateInput updateDto
    );
}
