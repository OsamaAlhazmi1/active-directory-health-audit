

using AD.HealthAudit.API.Data;
using AD.HealthAudit.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddLocalDb();
var app = builder.Build();

app.MigrateDb();

app.MapUserEndpoints();
app.MapComputerEndpoints();
app.MapDomainEndpoints();
app.MapGroupsEndpoints();

app.Run();
