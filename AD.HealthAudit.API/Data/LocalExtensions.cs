using AD.HealthAudit.API.Models;
using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.Data;

public static class LocalExtensions
{

    public static void AddLocalDb(this WebApplicationBuilder builder)
    {

        var connectionString = builder.Configuration.GetConnectionString("ADLocalDBKey");
        builder.Services.AddSqlite<LocalContext>(
             connectionString,
             optionsAction: option => option.UseSeeding((dbcontext, _) =>
             {
                SeedUsersGroupsAndComputers((LocalContext)dbcontext);
                SeedDomainAndDCs((LocalContext)dbcontext); 

             })
        );


    }
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<LocalContext>();
        db.Database.Migrate();

    }


    private static void SeedUsersGroupsAndComputers(LocalContext context)
    {
        if (context.Set<User>().Count() > 1)
            return;

        // ================= USERS =================

        var users = new List<User>
    {
                   new()
            {
                Name = "john.smith",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "sarah.connor",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "michael.brown",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Expired
            },

            new()
            {
                Name = "emma.wilson",
                AccountStatus = User.UserAccountStatus.Disabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "david.lee",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "alex.johnson",
                AccountStatus = User.UserAccountStatus.Disabled,
                PasswordStatus = User.UserPasswordStatus.Expired
            },

            new()
            {
                Name = "james.anderson",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "olivia.martin",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Expired
            },

            new()
            {
                Name = "daniel.white",
                AccountStatus = User.UserAccountStatus.Disabled,
                PasswordStatus = User.UserPasswordStatus.Active
            },

            new()
            {
                Name = "ethan.clark",
                AccountStatus = User.UserAccountStatus.Enabled,
                PasswordStatus = User.UserPasswordStatus.Active
            }
        };


        context.Users.AddRange(users);
        context.SaveChanges(); 

    }
        private static void SeedDomainAndDCs(LocalContext context)
    {
        if (context.Set<Domain>().Count() > 1)
            return;
        if (context.Set<DomainController>().Count()>1)
            return; 


        var HQ_Domain = new Domain()
        {
            Name = "HQ", 
            Status= Domain.DomainLDAPStatus.Available
        };



        var DCsList = new List<DomainController>
        {
            new()
            {
                Name = "HQ_DC1",
                Domain = HQ_Domain , 
                ConnectivityStatus = DomainController.DC_ConnectivityStatus.Available

            },
            new()
            {
                Name = "HQ_DC2",
                Domain = HQ_Domain , 
                ConnectivityStatus = DomainController.DC_ConnectivityStatus.Available

            },
            new()
            {
                Name = "HQ_DC3",
                Domain = HQ_Domain , 
                ConnectivityStatus = DomainController.DC_ConnectivityStatus.Unavailable

            },
            
            
        }; 
        context.Domain.Add(HQ_Domain);
        context.DomainController.AddRange(DCsList); 
        context.SaveChanges();

        
    }
}