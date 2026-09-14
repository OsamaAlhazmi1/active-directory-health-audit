using AD.HealthAudit.API.Data;
using AD.HealthAudit.API.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.EndPoints;

public static class DomainEndpoint
{


    public static void MapDomainEndpoints(this WebApplication app)
    {


        var groupName = app.MapGroup("/domain");

        groupName.MapGet("/{id}", async (int id, LocalContext dbcontext) =>
        {
            var domain = await dbcontext.Domain.FirstOrDefaultAsync(d => d.Id == id);

            if (domain == null)
                return Results.NotFound($"Domain With {id} Is not Found");

            var dto = new DomainDTO(
                Id: domain.Id,
                DomainName: domain.Name
            );

            return Results.Ok(dto);

        });
        groupName.MapGet("/by_name/{domianName}", async (string domianName, LocalContext dbcontext) =>
        {
            var domain = await dbcontext.Domain.FirstOrDefaultAsync(d => d.Name == domianName);

            if (domain == null)
                return Results.NotFound($"Domain With {domianName} Is not Found");

            var dto = new DomainDTO(
                Id: domain.Id,
                DomainName: domain.Name
            );

            return Results.Ok(dto);

        });

        


    }

}
