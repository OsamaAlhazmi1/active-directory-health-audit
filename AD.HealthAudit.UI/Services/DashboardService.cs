using AD.HealthAudit.UI.DTOs;

namespace AD.HealthAudit.UI.Services;

public class DashboardService
{
    private readonly HttpClient _httpClient;

    public DashboardService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<DashboardMainDTO?> GetMainDashboardAsync()
    {
        return await _httpClient.GetFromJsonAsync<DashboardMainDTO>(
            "dashboard/main");
    }
    public async Task<DashboardDomainDTO?> GetDomainDashboardAsync(int domainId)
    {
        return await _httpClient.GetFromJsonAsync<DashboardDomainDTO>(
            $"dashboard/domain/{domainId}");
    }
    public async Task<DomainDTO?> GetDomainAsync(int domainId)
    {
        return await _httpClient.GetFromJsonAsync<DomainDTO>(
            $"domain/{domainId}");
    }
    public async Task<List<DomainControllerDTO>> GetDomainControllersAsync(int domainID)
    {
        return await _httpClient.GetFromJsonAsync<List<DomainControllerDTO>>(
            $"dashboard/domain/{domainID}/controllers")
            ?? [];
    }
}