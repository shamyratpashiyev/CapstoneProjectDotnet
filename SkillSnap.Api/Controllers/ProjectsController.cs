using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
    public async Task<IActionResult> GetList()
    {
        var projectQueryable = _context.Projects.AsQueryable();
        var portfolioUserQueryable = _context.PortfolioUsers.AsQueryable();
        var query = from p in projectQueryable
            join pu in portfolioUserQueryable on p.PortfolioUserId equals pu.Id
            select new Project()
            {
                Id = p.Id,
                Title = p.Title,
                PortfolioUserId = pu.Id,
                Description = p.Description,
                ImageUrl = p.ImageUrl,
                PortfolioUser = pu
            };
        var projects = await query.ToListAsync();
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
