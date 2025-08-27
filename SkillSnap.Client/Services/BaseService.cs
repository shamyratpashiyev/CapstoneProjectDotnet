namespace SkillSnap.Client.Services;

public class BaseService
{
    public string ApiUrl { get; }

    public BaseService(IConfiguration configuration)
    {
        ApiUrl = configuration["Backend:ApiUrl"];
    }
}