namespace SkillSnap.Client.Dtos;

public class ProjectDto
{
    public int Id { get; set; }
    
    public string Title { get; set; }
    
    public string Description { get; set; }
    
    public string ImageUrl { get; set; }
    
    public int PortfolioUserId { get; set; }

    public PortfolioUserDto PortfolioUser { get; set; }
}