using Microsoft.AspNetCore.Mvc;
using SkillSnap.Api.Data;
using SkillSnap.Api.Models;

namespace SkillSnap.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SkillsController : ControllerBase
{
    private readonly SkillSnapContext _context;

    public SkillsController(SkillSnapContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        var skills = _context.Skills.ToList();
        return Ok(skills);
    }

    [HttpPost]
    public IActionResult Create(Skill skill)
    {
        var res = _context.Skills.Add(skill);
        _context.SaveChanges();
        return Created(string.Empty, res.Entity);
    }
}
