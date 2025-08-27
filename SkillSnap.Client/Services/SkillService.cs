using System.Net.Http.Json;
using SkillSnap.Client.Dtos;

namespace SkillSnap.Client.Services;

public class SkillService : BaseService
{
    private readonly HttpClient _client;

    public SkillService(HttpClient client,
                        IConfiguration configuration)
    : base(configuration)
    {
        _client = client;
    }
    
    public async Task<List<SkillDto>> GetListAsync()
    {
        return await _client.GetFromJsonAsync<List<SkillDto>>(this.ApiUrl + "Projects");
    }
    
    public async Task<SkillDto> CreateAsync(SkillDto input)
    {
        var res = await _client.PostAsJsonAsync<SkillDto>(this.ApiUrl + "Projects", input);
        return res.Content.ReadFromJsonAsync<SkillDto>().Result;
    }
}