using AluminumShopManagement.APIs.Common;
using AluminumShopManagement.APIs.Dtos;

namespace AluminumShopManagement.APIs;

public interface IServiceSchedulesService
{
    /// <summary>
    /// Create one ServiceSchedule
    /// </summary>
    public Task<ServiceSchedule> CreateServiceSchedule(ServiceScheduleCreateInput serviceschedule);

    /// <summary>
    /// Delete one ServiceSchedule
    /// </summary>
    public Task DeleteServiceSchedule(ServiceScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many ServiceSchedules
    /// </summary>
    public Task<List<ServiceSchedule>> ServiceSchedules(ServiceScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about ServiceSchedule records
    /// </summary>
    public Task<MetadataDto> ServiceSchedulesMeta(ServiceScheduleFindManyArgs findManyArgs);

    /// <summary>
    /// Get one ServiceSchedule
    /// </summary>
    public Task<ServiceSchedule> ServiceSchedule(ServiceScheduleWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one ServiceSchedule
    /// </summary>
    public Task UpdateServiceSchedule(
        ServiceScheduleWhereUniqueInput uniqueId,
        ServiceScheduleUpdateInput updateDto
    );
}
