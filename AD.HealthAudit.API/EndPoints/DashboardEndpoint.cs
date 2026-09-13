using AD.HealthAudit.API.Data;
using AD.HealthAudit.API.DTOs;
using AD.HealthAudit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.EndPoints;

public static class DashboardEndpoint
{


    public static void MapDashboardEndpoints(this WebApplication app)
    {


        var groupName = app.MapGroup("/dashboard");

        groupName.MapGet("/main", async (LocalContext dbcontext) =>
        {
            int numberOfUsers = await dbcontext.Users.CountAsync();

            int enabledUsers = await dbcontext.Users
                .CountAsync(u => u.AccountStatus == User.UserAccountStatus.Enabled);

            int disabledUsers = await dbcontext.Users
                .CountAsync(u => u.AccountStatus == User.UserAccountStatus.Disabled);

            int expiredPasswordsUsers = await dbcontext.Users
                .CountAsync(u => u.PasswordStatus == User.UserPasswordStatus.Expired);

            int numberOfComputers = await dbcontext.Computers.CountAsync();

            int enabledComputers = await dbcontext.Computers
                .CountAsync(u => u.Status == Computer.ComputerStatus.Enabled);

            int disabledComputers = await dbcontext.Computers
                .CountAsync(u => u.Status == Computer.ComputerStatus.Disabled);


            int numberOfGroups = await dbcontext.Groups.CountAsync();



            var dto = new DashboardMainDTO(
                numberOfUsers,
                enabledUsers,
                disabledUsers,
                expiredPasswordsUsers,
                numberOfComputers,
                enabledComputers,
                disabledComputers,
                numberOfGroups
                );

            return Results.Ok(dto);


        });


        groupName.MapGet("/domain/{domainName}", async (string domainName, LocalContext dbcontext) =>
        {
            var domain = await dbcontext.Domain.FirstOrDefaultAsync(d => d.Name == domainName);

            if (domain == null)
                return Results.NotFound($"Domain {domainName} Not Found ");


            int numberOfDCs = await dbcontext.DomainController
                .CountAsync(dc => dc.DomainID == domain.Id);

            int availableDCs = await dbcontext.DomainController
                .CountAsync(dc =>
                    dc.DomainID == domain.Id &&
                    dc.ConnectivityStatus ==
                        DomainController.DC_ConnectivityStatus.Available);

            int unavailableDCs = await dbcontext.DomainController
                .CountAsync(dc =>
                    dc.DomainID == domain.Id &&
                    dc.ConnectivityStatus ==
                        DomainController.DC_ConnectivityStatus.Unavailable);


            var dto = new DashboardDomainDTO(
                numberOfDCs,
                availableDCs,
                unavailableDCs
            );

            return Results.Ok(dto);


        });




    }

}
