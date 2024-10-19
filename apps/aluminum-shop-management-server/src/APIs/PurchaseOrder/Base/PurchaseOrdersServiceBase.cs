using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using AluminumShopManagement.APIs.Extensions;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.APIs;

public abstract class PurchaseOrdersServiceBase : IPurchaseOrdersService
{
    protected readonly AluminumShopManagementDbContext _context;

    public PurchaseOrdersServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one PurchaseOrder
    /// </summary>
    public async Task<PurchaseOrder> CreatePurchaseOrder(PurchaseOrderCreateInput createDto)
    {
        var purchaseOrder = new PurchaseOrderDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            purchaseOrder.Id = createDto.Id;
        }

        _context.PurchaseOrders.Add(purchaseOrder);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<PurchaseOrderDbModel>(purchaseOrder.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one PurchaseOrder
    /// </summary>
    public async Task DeletePurchaseOrder(PurchaseOrderWhereUniqueInput uniqueId)
    {
        var purchaseOrder = await _context.PurchaseOrders.FindAsync(uniqueId.Id);
        if (purchaseOrder == null)
        {
            throw new NotFoundException();
        }

        _context.PurchaseOrders.Remove(purchaseOrder);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many PurchaseOrders
    /// </summary>
    public async Task<List<PurchaseOrder>> PurchaseOrders(PurchaseOrderFindManyArgs findManyArgs)
    {
        var purchaseOrders = await _context
            .PurchaseOrders.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return purchaseOrders.ConvertAll(purchaseOrder => purchaseOrder.ToDto());
    }

    /// <summary>
    /// Meta data about PurchaseOrder records
    /// </summary>
    public async Task<MetadataDto> PurchaseOrdersMeta(PurchaseOrderFindManyArgs findManyArgs)
    {
        var count = await _context.PurchaseOrders.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one PurchaseOrder
    /// </summary>
    public async Task<PurchaseOrder> PurchaseOrder(PurchaseOrderWhereUniqueInput uniqueId)
    {
        var purchaseOrders = await this.PurchaseOrders(
            new PurchaseOrderFindManyArgs
            {
                Where = new PurchaseOrderWhereInput { Id = uniqueId.Id }
            }
        );
        var purchaseOrder = purchaseOrders.FirstOrDefault();
        if (purchaseOrder == null)
        {
            throw new NotFoundException();
        }

        return purchaseOrder;
    }

    /// <summary>
    /// Update one PurchaseOrder
    /// </summary>
    public async Task UpdatePurchaseOrder(
        PurchaseOrderWhereUniqueInput uniqueId,
        PurchaseOrderUpdateInput updateDto
    )
    {
        var purchaseOrder = updateDto.ToModel(uniqueId);

        _context.Entry(purchaseOrder).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.PurchaseOrders.Any(e => e.Id == purchaseOrder.Id))
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
