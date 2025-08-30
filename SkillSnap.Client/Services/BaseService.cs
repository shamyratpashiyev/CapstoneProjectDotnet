namespace SkillSnap.Client.Services;

public class BaseService
{
    protected string ApiUrl { get; }

    public BaseService(IConfiguration configuration)
    {
        ApiUrl = configuration["Backend:ApiUrl"];
    }
}