using AD.HealthAudit.API.DTOs;

namespace AD.HealthAudit.API.EndPoints;

public static class DomainEndpoint
{

    
    public static void  MapDomainEndpoints(this WebApplication app)
    {
     

        var groupName = app.MapGroup("/User");

    
    }
    
}
