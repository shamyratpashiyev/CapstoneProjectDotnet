using System.Net.Http.Json;
using SkillSnap.Client.Dtos;

namespace SkillSnap.Client.Services;


public class ProjectService : BaseService
{
    private readonly HttpClient _client;
    
    public ProjectService(HttpClient client,
                        IConfiguration configuration)
        : base(configuration)
    {
        _client = client;
    }
    
    public async Task<List<ProjectDto>> GetListAsync()
    {
        return await _client.GetFromJsonAsync<List<ProjectDto>>(this.ApiUrl + "Projects");
    }
    
    public async Task<ProjectDto> CreateAsync(ProjectDto input)
    {
        var res = await _client.PostAsJsonAsync(this.ApiUrl + "Projects", input);
        return res.Content.ReadFromJsonAsync<ProjectDto>().Result;
    }
}