using Business.Services;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProjectsController(ProjectService projectService) : ControllerBase
{
    private readonly ProjectService _projectService = projectService;

    [HttpPost]
    public async Task<IActionResult> Create(AddProjectFormData project)
    {
        if (!ModelState.IsValid)
            return BadRequest(project);

        var result = await _projectService.CreateProjectAsync(project);
        return result ? Ok() : BadRequest();
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var projects = await _projectService.GetAllProjectsAsync(orderByDescending: true);
        return Ok(projects);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        var project = await _projectService.GetProjectByIdAsync(id);
        return project == null ? NotFound() : Ok(project);
    }

    [HttpPut]
    public async Task<IActionResult> Update(UpdateProjectFormData project)
    {
        if (!ModelState.IsValid)
            return BadRequest(project);

        var result = await _projectService.UpdateProjectAsync(project);
        return result ? Ok() : NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        if (string.IsNullOrEmpty(id))
            return BadRequest();

        var result = await _projectService.DeleteProjectAsync(id);
        return result ? Ok() : NotFound();
    }
}