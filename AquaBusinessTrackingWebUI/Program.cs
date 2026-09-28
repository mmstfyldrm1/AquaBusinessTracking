using AquaBusinessTrackingWebUI.Controllers;
using AquaBusinessTrackingWebUI.Models;
using AquaBusinessTrackingWebUI.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Claims;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews(options =>
{
    options.Filters.AddService<InjectAuthViewDataFilter>();
})
.AddSessionStateTempDataProvider();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();
builder.Services.AddScoped<AuthorizedHttpClientService>();
builder.Services.AddScoped<ModalService>();
builder.Services.AddScoped<UserFavoriteService>();
builder.Services.AddScoped<CurrentUserService>();
builder.Services.AddScoped<ProductionDetailBuilder>();
builder.Services.AddScoped<InjectAuthViewDataFilter>();
builder.Services.Configure<ApiSettings>(
    builder.Configuration.GetSection("ApiSettings"));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.LoginPath = "/Auth/login";
        options.LogoutPath = "/Auth/logout";
        options.AccessDeniedPath = "/Auth/AccessDenied";
        options.Cookie.Name = "AquaAuth";
        options.Cookie.HttpOnly = true;
        options.Cookie.SameSite = SameSiteMode.Lax;

        // Süreyi Login'de ExpiresUtc = JWT bitiþi olarak veriyoruz, uzamasýn
        options.SlidingExpiration = false;

        // JWT süresi dolduysa cookie'yi de geçersiz say
        options.Events.OnValidatePrincipal = async context =>
        {
            var exp = context.Principal?.FindFirst("exp")?.Value;
            if (long.TryParse(exp, out var unix) &&
                DateTimeOffset.FromUnixTimeSeconds(unix) < DateTimeOffset.UtcNow)
            {
                context.RejectPrincipal();
                await context.HttpContext.SignOutAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme);
                context.HttpContext.Response.Cookies.Delete("AuthToken");
            }
        };
    });

builder.Services.AddAuthorization();

builder.Services.AddDataProtection()
    .PersistKeysToFileSystem(new DirectoryInfo(@"C:\Aqua\DataProtection-Keys"))
    .SetApplicationName("AquaBusinessTracking");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();
app.UseAuthentication();

// Cookie geçerli ama session boþsa (restart, timeout, tarayýcý kapanmasý)
// session'ý claim'lerden yeniden doldur
app.Use(async (context, next) =>
{
    if (context.User.Identity?.IsAuthenticated == true &&
        string.IsNullOrEmpty(context.Session.GetString("UserId")))
    {
        var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (!string.IsNullOrEmpty(userId))
            context.Session.SetString("UserId", userId);

        var userName = context.User.FindFirst(ClaimTypes.Name)?.Value;
        if (!string.IsNullOrEmpty(userName))
            context.Session.SetString("UserName", userName);

        var token = context.Request.Cookies["AuthToken"];
        if (!string.IsNullOrEmpty(token))
            context.Session.SetString("Token", token);

        // Dashboard'un session'dan okuduðu diðer key'leri buraya ekle
    }

    await next();
});

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();