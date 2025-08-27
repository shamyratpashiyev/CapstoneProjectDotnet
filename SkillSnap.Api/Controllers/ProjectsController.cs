using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectsController : ControllerBase
{
    private readonly SkillSnapContext _context;

    public ProjectsController(SkillSnapContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var projects = _context.Projects.ToList();
        return Ok(projects);
    }

    [HttpPost]
    public IActionResult Create(Project project)
    {
        var res = _context.Projects.Add(project);
        _context.SaveChanges();
        return Created(string.Empty, res.Entity);
    }
}
