using SRS.Infrastructure.Bus;
using SRS.Infrastructure.Logging;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddBusExtensions();
builder.Services.AddLoggerCustom(builder.Configuration);

var app = builder.Build();



app.MapGet("/", () => "Hello World!");



app.UseBusExtensions(app.Environment);
app.Run();