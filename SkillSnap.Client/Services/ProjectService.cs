using System.Net.Http.Json;
using System.Text.Json;
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
        var response = await _client.GetAsync(ApiUrl + "Projects");
        response.EnsureSuccessStatusCode();

        return await response.Content.ReadFromJsonAsync<List<ProjectDto>>();
    }
    
    public async Task<ProjectDto> CreateAsync(ProjectDto input)
    {
        var res = await _client.PostAsJsonAsync(this.ApiUrl + "Projects", input);
        return res.Content.ReadFromJsonAsync<ProjectDto>().Result;
    }
}