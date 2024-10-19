using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using AluminumShopManagement.APIs.Extensions;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.APIs;

public abstract class ServiceHistoriesServiceBase : IServiceHistoriesService
{
    protected readonly AluminumShopManagementDbContext _context;

    public ServiceHistoriesServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceHistory
    /// </summary>
    public async Task<ServiceHistory> CreateServiceHistory(ServiceHistoryCreateInput createDto)
    {
        var serviceHistory = new ServiceHistoryDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceHistory.Id = createDto.Id;
        }

        _context.ServiceHistories.Add(serviceHistory);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceHistoryDbModel>(serviceHistory.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceHistory
    /// </summary>
    public async Task DeleteServiceHistory(ServiceHistoryWhereUniqueInput uniqueId)
    {
        var serviceHistory = await _context.ServiceHistories.FindAsync(uniqueId.Id);
        if (serviceHistory == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceHistories.Remove(serviceHistory);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceHistories
    /// </summary>
    public async Task<List<ServiceHistory>> ServiceHistories(
        ServiceHistoryFindManyArgs findManyArgs
    )
    {
        var serviceHistories = await _context
            .ServiceHistories.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceHistories.ConvertAll(serviceHistory => serviceHistory.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceHistory records
    /// </summary>
    public async Task<MetadataDto> ServiceHistoriesMeta(ServiceHistoryFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceHistories.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceHistory
    /// </summary>
    public async Task<ServiceHistory> ServiceHistory(ServiceHistoryWhereUniqueInput uniqueId)
    {
        var serviceHistories = await this.ServiceHistories(
            new ServiceHistoryFindManyArgs
            {
                Where = new ServiceHistoryWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceHistory = serviceHistories.FirstOrDefault();
        if (serviceHistory == null)
        {
            throw new NotFoundException();
        }

        return serviceHistory;
    }

    /// <summary>
    /// Update one ServiceHistory
    /// </summary>
    public async Task UpdateServiceHistory(
        ServiceHistoryWhereUniqueInput uniqueId,
        ServiceHistoryUpdateInput updateDto
    )
    {
        var serviceHistory = updateDto.ToModel(uniqueId);

        _context.Entry(serviceHistory).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceHistories.Any(e => e.Id == serviceHistory.Id))
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
