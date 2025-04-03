using Data.Enitties;
using Data.Repositories;
using Domain.Models;

namespace Business.Services;

public class ProjectService(ProjectRepository projectRepository)
{
    private readonly ProjectRepository _projectRepository = projectRepository;

    public async Task<bool> CreateProjectAsync(AddProjectFormData projectFormData)
    {
        if (projectFormData == null)
            return false;

        var entity = new ProjectEntity
        {
            ProjectName = projectFormData.ProjectName,
            Description = projectFormData.Description,
            StartDate = projectFormData.StartDate,
            EndDate = projectFormData.EndDate,
            Budget = projectFormData.Budget,
            ClientId = projectFormData.ClientId,
            StatusId = 1,
            UserId = projectFormData.UserId
        };
        var result = await _projectRepository.AddAsync(entity);
        return result;
    }

    public async Task<IEnumerable<Project>> GetAllProjectsAsync(bool orderByDescending = false)
    {
        var entities = await _projectRepository.GetAllAsync();
        var projects = entities.Select(e => new Project
        {
            Id = e.Id,
            ProjectName = e.ProjectName,
            Description = e.Description,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            Budget = e.Budget,
            Created = e.Created,
            Client = new Client
            {
                Id = e.Client.Id,
                ClientName = e.Client.ClientName
            },
            Status = new Status
            {
                Id = e.Status.Id,
                StatusName = e.Status.StatusName
            },
            User = new Member
            {
                Id = e.User.Id,
                FirstName = e.User.FirstName,
                LastName = e.User.LastName
            }
        });
        return orderByDescending
            ? projects.OrderByDescending(e => e.Created)
            : projects.OrderBy(e => e.Created);
    }

    public async Task<Project?> GetProjectByIdAsync(string id)
    {
        var entity = await _projectRepository.GetAsync(e => e.Id == id);
        return entity == null ? null : new Project
        {
            Id = entity.Id,
            ProjectName = entity.ProjectName,
            Description = entity.Description,
            StartDate = entity.StartDate,
            EndDate = entity.EndDate,
            Budget = entity.Budget,
            Created = entity.Created,
            Client = new Client
            {
                Id = entity.Client.Id,
                ClientName = entity.Client.ClientName
            },
            Status = new Status
            {
                Id = entity.Status.Id,
                StatusName = entity.Status.StatusName
            },
            User = new Member
            {
                Id = entity.User.Id,
                FirstName = entity.User.FirstName,
                LastName = entity.User.LastName
            }
        };
    }

    public async Task<bool> UpdateProjectAsync(UpdateProjectFormData projectFormData)
    {
        if (projectFormData == null)
            return false;

        var entity = new ProjectEntity
        {
            Id = projectFormData.Id,
            ProjectName = projectFormData.ProjectName,
            Description = projectFormData.Description,
            StartDate = projectFormData.StartDate,
            EndDate = projectFormData.EndDate,
            Budget = projectFormData.Budget,
            ClientId = projectFormData.ClientId,
            StatusId = projectFormData.StatusId,
            UserId = projectFormData.UserId
        };
        var result = await _projectRepository.UpdateAsync(entity);
        return result;
    }

    public async Task<bool> DeleteProjectAsync(string id)
    {
        if (string.IsNullOrEmpty(id))
            return false;

        var result = await _projectRepository.DeleteAsync(e => e.Id == id);
        return result;
    }
}
