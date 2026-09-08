using AD.HealthAudit.API.DTOs;

namespace AD.HealthAudit.API.EndPoints;

public static class UserEndpoint
{

    
    public static void  MapUserEndpoints(this WebApplication app)
    {
     

        var userGroupName = app.MapGroup("/User");

    
    }
    
}
