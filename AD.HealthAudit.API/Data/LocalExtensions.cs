using Microsoft.EntityFrameworkCore;

namespace AD.HealthAudit.API.Data;

public static class LocalExtensions
{

    public static void AddLocalDb(this WebApplicationBuilder builder){

        var connectionString = builder.Configuration.GetConnectionString("ADLocalDBKey");
        builder.Services.AddSqlite<LocalContext>(connectionString);

    }
        public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<LocalContext>();
        db.Database.Migrate();
    }
}
