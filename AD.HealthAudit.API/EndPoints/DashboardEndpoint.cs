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

            int enabledComputers= await dbcontext.Computers
                .CountAsync(u => u.Status == Computer.ComputerStatus.Enabled);

            int disabledComputers= await dbcontext.Computers
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


        groupName.MapGet("/domianDCs" , async (DomainDTO domainDTO,LocalContext dbcontext) =>
        {
            int numberOfDCs = await dbcontext.Domians.CountAsync( u => u.Name == domainDTO.DomainName ); 


            int availableDCs= await dbcontext.Domians
                .CountAsync(u => u.Status == Domain.DomainLDAPStatus.Available);
            
            int unavailableDCs = await dbcontext.Domians
                .CountAsync(u => u.Status == Domain.DomainLDAPStatus.Unavailable);


            var dto = new DashboardDomainDTO (
                numberOfDCs, 
                availableDCs,
                unavailableDCs
            );


        });

    


    }

}
