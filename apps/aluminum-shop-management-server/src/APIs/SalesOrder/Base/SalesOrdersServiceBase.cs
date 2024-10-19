using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using AluminumShopManagement.APIs.Extensions;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.APIs;

public abstract class SalesOrdersServiceBase : ISalesOrdersService
{
    protected readonly AluminumShopManagementDbContext _context;

    public SalesOrdersServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one SalesOrder
    /// </summary>
    public async Task<SalesOrder> CreateSalesOrder(SalesOrderCreateInput createDto)
    {
        var salesOrder = new SalesOrderDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            salesOrder.Id = createDto.Id;
        }

        _context.SalesOrders.Add(salesOrder);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<SalesOrderDbModel>(salesOrder.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one SalesOrder
    /// </summary>
    public async Task DeleteSalesOrder(SalesOrderWhereUniqueInput uniqueId)
    {
        var salesOrder = await _context.SalesOrders.FindAsync(uniqueId.Id);
        if (salesOrder == null)
        {
            throw new NotFoundException();
        }

        _context.SalesOrders.Remove(salesOrder);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many SalesOrders
    /// </summary>
    public async Task<List<SalesOrder>> SalesOrders(SalesOrderFindManyArgs findManyArgs)
    {
        var salesOrders = await _context
            .SalesOrders.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return salesOrders.ConvertAll(salesOrder => salesOrder.ToDto());
    }

    /// <summary>
    /// Meta data about SalesOrder records
    /// </summary>
    public async Task<MetadataDto> SalesOrdersMeta(SalesOrderFindManyArgs findManyArgs)
    {
        var count = await _context.SalesOrders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one SalesOrder
    /// </summary>
    public async Task<SalesOrder> SalesOrder(SalesOrderWhereUniqueInput uniqueId)
    {
        var salesOrders = await this.SalesOrders(
            new SalesOrderFindManyArgs { Where = new SalesOrderWhereInput { Id = uniqueId.Id } }
        );
        var salesOrder = salesOrders.FirstOrDefault();
        if (salesOrder == null)
        {
            throw new NotFoundException();
        }

        return salesOrder;
    }

    /// <summary>
    /// Update one SalesOrder
    /// </summary>
    public async Task UpdateSalesOrder(
        SalesOrderWhereUniqueInput uniqueId,
        SalesOrderUpdateInput updateDto
    )
    {
        var salesOrder = updateDto.ToModel(uniqueId);

        _context.Entry(salesOrder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.SalesOrders.Any(e => e.Id == salesOrder.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
