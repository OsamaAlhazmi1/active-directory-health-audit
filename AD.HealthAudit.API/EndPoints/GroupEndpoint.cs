using AD.HealthAudit.API.DTOs;

namespace AD.HealthAudit.API.EndPoints;

public static class GroupEndpoint
{

    
    public static void  MapGroupsEndpoints(this WebApplication app)
    {
     

        var groupName = app.MapGroup("/User");

    
    }
    
}
