using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Report.Identity.Data;
using Report.Identity.Models;

namespace Report.Identity;

public class Startup
{
    public IConfiguration AppConfiguration { get; }

    public Startup(IConfiguration configuration) =>
        AppConfiguration = configuration;

    public void ConfigureServices(IServiceCollection services)
    {
        var connectionString = AppConfiguration.GetValue<string>("DbConnection");

        services.AddDbContext<AuthDbContext>(options =>
        {
            options.UseNpgsql(  connectionString);
        });

        services.AddIdentity<AppUser, IdentityRole>(config =>
            {
                config.Password.RequiredLength = 4;
                config.Password.RequireDigit = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
            })
            .AddEntityFrameworkStores<AuthDbContext>()
            .AddDefaultTokenProviders();

        services.AddIdentityServer()
            .AddAspNetIdentity<AppUser>()
            .AddInMemoryApiResources(Configuration.ApiResources)
            .AddInMemoryIdentityResources(Configuration.IdentityResources)
            .AddInMemoryApiScopes(Configuration.ApiScopes)
            .AddInMemoryClients(Configuration.Clients)
            .AddDeveloperSigningCredential();

        services.ConfigureApplicationCookie(config =>
        {
            config.Cookie.Name = "Reports.Identity.Cookie";
            config.LoginPath = "/Auth/Login";
            config.LogoutPath = "/Auth/Logout";
        });

        services.AddControllersWithViews();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(env.ContentRootPath, "Styles")),
            RequestPath = "/styles"
        });
        app.UseRouting();
        app.UseIdentityServer();
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapDefaultControllerRoute();
        });
    }
}