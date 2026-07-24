using AquaBusinessTrackingWebApi.Containers;
using AquaBusinessTrackingWebApi.Services;
using DataAccsessLayer;
using DataAccsessLayer.Seed;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;
using System.Text;



var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .Enrich.WithThreadId()
    .Enrich.WithProcessId()
    .WriteTo.Console()


    // API Loglarý
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(x =>
            !x.Properties.ContainsKey("SourceContext") ||
            !x.Properties["SourceContext"]
            .ToString()
            .Contains("OpcUaPlcReader"))
        .WriteTo.File(
            "Logs/Api/api-.txt",
            rollingInterval: RollingInterval.Day)

        .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            {
                TableName = "ApiLogs",
                AutoCreateSqlTable = true
            })
    )


    // PLC Loglarý
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(x =>
            x.Properties.ContainsKey("SourceContext") &&
            x.Properties["SourceContext"]
            .ToString()
            .Contains("OpcUaPlcReader"))
        .WriteTo.File(
            "Logs/Plc/plc-.txt",
            rollingInterval: RollingInterval.Day)

        .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            {
                TableName = "PlcLogs",
                AutoCreateSqlTable = true
            })
    )


    // Error Loglarý
    .WriteTo.Logger(lc => lc
        .Filter.ByIncludingOnly(x =>
            x.Level == LogEventLevel.Error ||
            x.Level == LogEventLevel.Fatal)

        .WriteTo.File(
            "Logs/Error/error-.txt",
            rollingInterval: RollingInterval.Day)

        .WriteTo.MSSqlServer(
            connectionString: builder.Configuration.GetConnectionString("DefaultConnection"),
            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            {
                TableName = "ErrorLogs",
                AutoCreateSqlTable = true
            })
    )


    .CreateLogger();


builder.Host.UseSerilog();



// Add services to the container.

builder.Services.AddControllers();
builder.Services.ContainerDependencies();
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddMaps(AppDomain.CurrentDomain.GetAssemblies());
});
builder.Services.AddDbContext<AquaBusinessTrackingContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddIdentity<DB_AppUser, DB_AppRole>()
    .AddEntityFrameworkStores<AquaBusinessTrackingContext>()
    .AddDefaultTokenProviders();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        x => x.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials());
});

// JWT (tek blok - hem TokenValidationParameters hem Events burada)
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
    };

    options.Events = new JwtBearerEvents
    {
        OnMessageReceived = context =>
        {
            var accessToken = context.Request.Query["access_token"];
            var path = context.HttpContext.Request.Path;

            if (!string.IsNullOrEmpty(accessToken) &&
                path.StartsWithSegments("/messageHub"))
            {
                context.Token = accessToken;
            }

            return Task.CompletedTask;
        }
    };
});

// Swagger JWT
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Bearer {token}"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id   = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
});


builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\AquaAPI\DataProtection-Keys"))
    .SetApplicationName("AquaBusinessTracking");

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<AquaBusinessTrackingContext>();

    await PermissionSeed.SeedAsync(context);

    if (!context.Db_Permission.Any())
    {
        await PermissionSeed.SeedAsync(context);
    }
}

app.UseCors("AllowAll");

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}



app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
    c.RoutePrefix = "swagger";
});

app.UseSerilogRequestLogging(options =>
{
    options.MessageTemplate =
        "HTTP {RequestMethod} {RequestPath} responded {StatusCode} in {Elapsed:0.0000} ms";
});

app.UseMiddleware<ExceptionMiddleware>();

app.MapHub<PlcHub>("/hubs/plc");
app.MapHub<MessageHub>("/messageHub");

//app.UseHttpsRedirection();
app.UseAuthentication();
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

app.Run();