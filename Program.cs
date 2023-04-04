
using System.IdentityModel.Tokens.Jwt;
using Serilog;
using sistema_venta_erp;

var builder = WebApplication.CreateBuilder(args);
/*limpiar claim*/
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
/* config serilog */
builder.Host.UseSerilog();
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/Log-.log", Serilog.Events.LogEventLevel.Warning, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u15}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
startup.Configure(app, app.Environment); // calling Configure method
app.Run("http://localhost:4000");
