using Data.Repositories;
using Domain.Models;

namespace Business.Services;

public class StatusService(StatusRepository statusRepository)
{
    private readonly StatusRepository _statusRepository = statusRepository;

    public async Task<IEnumerable<Status>> GetAllStatusesAsync()
    {
        var entities = await _statusRepository.GetAllAsync();
        var statuses = entities.Select(e => new Status
        {
            Id = e.Id,
            StatusName = e.StatusName
        });
        return statuses;
    }

    public async Task<Status?> GetStatusByIdAsync(int id)
    {
        var entity = await _statusRepository.GetAsync(e => e.Id == id);
        return entity == null ? null : new Status
        {
            Id = entity.Id,
            StatusName = entity.StatusName
        };
    }
}

