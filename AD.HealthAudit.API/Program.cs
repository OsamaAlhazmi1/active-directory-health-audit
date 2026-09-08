

using AD.HealthAudit.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUserEndpoints();
app.MapComputerEndpoints();
app.MapDomainEndpoints();
app.MapGroupsEndpoints();

app.Run();
