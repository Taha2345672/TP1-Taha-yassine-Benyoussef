using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Projet.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddSingleton<BaseDeDonnees>();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");

builder.Services.AddMvc()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportedCultures = new[]
    {
        new CultureInfo("fr-FR"),
        new CultureInfo("en-US")
    };

    options.DefaultRequestCulture = new RequestCulture("fr-FR");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStaticFiles(new StaticFileOptions
    {
        OnPrepareResponse = context => context.Context.Response.Headers.Add("Cache-Control", "no-cache")
    });
}
else
{
    app.UseStaticFiles();
}

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action}/{id?}",
        defaults: new { controller = "Home", action = "Index" });
});

app.MapRazorPages();
app.Run();

// Doc
// Environnements: https://learn.microsoft.com/en-us/aspnet/core/fundamentals/environments?view=aspnetcore-7.0
// Fichiers statiques et wwwroot : https://learn.microsoft.com/en-us/aspnet/core/fundamentals/static-files?view=aspnetcore-7.0
// Gestion de la cache : https://learn.microsoft.com/en-us/aspnet/core/performance/caching/response?view=aspnetcore-7.0