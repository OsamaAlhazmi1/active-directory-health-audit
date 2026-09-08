using AD.HealthAudit.API.DTOs;

namespace AD.HealthAudit.API.EndPoints;

public static class ComputerEndpoint
{

    
    public static void  MapComputerEndpoints(this WebApplication app)
    {
     

        var groupName = app.MapGroup("/User");

    
    }
    
}
