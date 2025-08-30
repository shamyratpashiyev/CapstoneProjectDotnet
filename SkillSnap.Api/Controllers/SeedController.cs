using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SeedController : ControllerBase
{
    private readonly SkillSnapContext _context;
    public SeedController(SkillSnapContext context)
    {
        _context = context;
    }
    [HttpPost]
    public IActionResult Seed()
    {
        if (_context.PortfolioUsers.Any())
        {
            return BadRequest("Sample data already exists.");
        }
        var user = new PortfolioUser()
        {
            Name = "Jordan Developer",
            Bio = "Full-stack developer passionate about learning new tech.",
            ProfileImageUrl = "https://example.com/images/jordan.png",
            Projects = new List<Project>
            {
                new Project { Title = "Task Tracker", Description = "Manage tasks effectively", ImageUrl = "https://picsum.photos/300/200" },
                new Project { Title = "Weather App", Description = "Forecast weather using APIs", ImageUrl = "https://picsum.photos/300/200" }
            },
            Skills = new List<Skill>
            {
                new Skill { Name = "C#", Level = "Advanced" },
                new Skill { Name = "Blazor", Level = "Intermediate" }
            }
        };
        _context.PortfolioUsers.Add(user);
        _context.SaveChanges();
        return Ok("Sample data inserted.");
    }
}