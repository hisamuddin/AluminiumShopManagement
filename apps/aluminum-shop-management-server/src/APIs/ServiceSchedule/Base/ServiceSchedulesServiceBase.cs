using AluminumShopManagement.APIs;
using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;
using AluminumShopManagement.APIs.Errors;
using AluminumShopManagement.APIs.Extensions;
using AluminumShopManagement.Infrastructure;
using AluminumShopManagement.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace AluminumShopManagement.APIs;

public abstract class ServiceSchedulesServiceBase : IServiceSchedulesService
{
    protected readonly AluminumShopManagementDbContext _context;

    public ServiceSchedulesServiceBase(AluminumShopManagementDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one ServiceSchedule
    /// </summary>
    public async Task<ServiceSchedule> CreateServiceSchedule(ServiceScheduleCreateInput createDto)
    {
        var serviceSchedule = new ServiceScheduleDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            serviceSchedule.Id = createDto.Id;
        }

        _context.ServiceSchedules.Add(serviceSchedule);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<ServiceScheduleDbModel>(serviceSchedule.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one ServiceSchedule
    /// </summary>
    public async Task DeleteServiceSchedule(ServiceScheduleWhereUniqueInput uniqueId)
    {
        var serviceSchedule = await _context.ServiceSchedules.FindAsync(uniqueId.Id);
        if (serviceSchedule == null)
        {
            throw new NotFoundException();
        }

        _context.ServiceSchedules.Remove(serviceSchedule);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many ServiceSchedules
    /// </summary>
    public async Task<List<ServiceSchedule>> ServiceSchedules(
        ServiceScheduleFindManyArgs findManyArgs
    )
    {
        var serviceSchedules = await _context
            .ServiceSchedules.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return serviceSchedules.ConvertAll(serviceSchedule => serviceSchedule.ToDto());
    }

    /// <summary>
    /// Meta data about ServiceSchedule records
    /// </summary>
    public async Task<MetadataDto> ServiceSchedulesMeta(ServiceScheduleFindManyArgs findManyArgs)
    {
        var count = await _context.ServiceSchedules.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one ServiceSchedule
    /// </summary>
    public async Task<ServiceSchedule> ServiceSchedule(ServiceScheduleWhereUniqueInput uniqueId)
    {
        var serviceSchedules = await this.ServiceSchedules(
            new ServiceScheduleFindManyArgs
            {
                Where = new ServiceScheduleWhereInput { Id = uniqueId.Id }
            }
        );
        var serviceSchedule = serviceSchedules.FirstOrDefault();
        if (serviceSchedule == null)
        {
            throw new NotFoundException();
        }

        return serviceSchedule;
    }

    /// <summary>
    /// Update one ServiceSchedule
    /// </summary>
    public async Task UpdateServiceSchedule(
        ServiceScheduleWhereUniqueInput uniqueId,
        ServiceScheduleUpdateInput updateDto
    )
    {
        var serviceSchedule = updateDto.ToModel(uniqueId);

        _context.Entry(serviceSchedule).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.ServiceSchedules.Any(e => e.Id == serviceSchedule.Id))
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
