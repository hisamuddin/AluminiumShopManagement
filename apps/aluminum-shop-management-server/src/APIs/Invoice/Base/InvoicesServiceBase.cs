using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using AluminumShopManagement.APIs.Extensions;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.APIs;

public abstract class InvoicesServiceBase : IInvoicesService
{
    protected readonly AluminumShopManagementDbContext _context;

    public InvoicesServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Invoice
    /// </summary>
    public async Task<Invoice> CreateInvoice(InvoiceCreateInput createDto)
    {
        var invoice = new InvoiceDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            invoice.Id = createDto.Id;
        }

        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<InvoiceDbModel>(invoice.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Invoice
    /// </summary>
    public async Task DeleteInvoice(InvoiceWhereUniqueInput uniqueId)
    {
        var invoice = await _context.Invoices.FindAsync(uniqueId.Id);
        if (invoice == null)
        {
            throw new NotFoundException();
        }

        _context.Invoices.Remove(invoice);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Invoices
    /// </summary>
    public async Task<List<Invoice>> Invoices(InvoiceFindManyArgs findManyArgs)
    {
        var invoices = await _context
            .Invoices.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return invoices.ConvertAll(invoice => invoice.ToDto());
    }

    /// <summary>
    /// Meta data about Invoice records
    /// </summary>
    public async Task<MetadataDto> InvoicesMeta(InvoiceFindManyArgs findManyArgs)
    {
        var count = await _context.Invoices.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Invoice
    /// </summary>
    public async Task<Invoice> Invoice(InvoiceWhereUniqueInput uniqueId)
    {
        var invoices = await this.Invoices(
            new InvoiceFindManyArgs { Where = new InvoiceWhereInput { Id = uniqueId.Id } }
        );
        var invoice = invoices.FirstOrDefault();
        if (invoice == null)
        {
            throw new NotFoundException();
        }

        return invoice;
    }

    /// <summary>
    /// Update one Invoice
    /// </summary>
    public async Task UpdateInvoice(InvoiceWhereUniqueInput uniqueId, InvoiceUpdateInput updateDto)
    {
        var invoice = updateDto.ToModel(uniqueId);

        _context.Entry(invoice).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Invoices.Any(e => e.Id == invoice.Id))
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
