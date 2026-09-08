

using AD.HealthAudit.API.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapUserEndpoints();

app.Run();
