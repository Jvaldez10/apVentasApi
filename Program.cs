
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Serilog;
using sistema_venta_erp;

var builder = WebApplication.CreateBuilder(args);
/*limpiar claim*/
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
/* config serilog */
builder.Host.UseSerilog();
//add authorize


Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Information)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .WriteTo.File("Logs/Log-.log", Serilog.Events.LogEventLevel.Warning, rollingInterval: RollingInterval.Day, outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u15}] {Message:lj}{NewLine}{Exception}")
    .CreateLogger();

// Add services to the container.

var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
.AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = false,
    ValidateAudience = false,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    IssuerSigningKey = new SymmetricSecurityKey(
        Encoding.UTF8.GetBytes(builder.Configuration.GetSection("KeyTokken").Value)
    ),
    ClockSkew = TimeSpan.Zero
});


var app = builder.Build();
startup.Configure(app, app.Environment); // calling Configure method
app.Run("http://localhost:3000");
