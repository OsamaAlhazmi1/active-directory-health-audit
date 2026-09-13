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
}