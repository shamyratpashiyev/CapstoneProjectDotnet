namespace SkillSnap.Client.Dtos;

public class PortfolioUserDto
{
    public int Id { get; set; }
    
    public string Name { get; set; }
    
    public string Bio { get; set; }
    
    public string ProfileImageUrl { get; set; }
    
    public List<ProjectDto> Projects { get; set; }
    
    public List<SkillDto> Skills { get; set; }
}