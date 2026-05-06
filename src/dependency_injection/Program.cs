using Autofac;
using Autofac.Extensions.DependencyInjection;
using dependency_injection.Codes;
using dependency_injection.Interface;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.File("logs/web-log-.log")
    .CreateBootstrapLogger();
try
{
    var builder = WebApplication.CreateBuilder(args);

    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection1") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

    // Add services to the container.
    builder.Services.AddControllersWithViews();

    #region deoebdency injection through service collection methods
    //builder.Services.AddScoped<IMembership, Membership>();
    //builder.Services.AddSingleton<IMembership, Membership>();
    //builder.Services.AddTransient<IMembership, Membership>();

    builder.Services.AddKeyedScoped<IMembership, Membership>(
    "DefaultMembership",
    (sp, key) => new Membership(connectionString)
);

    builder.Services.AddKeyedScoped<IMembership, MembershipImprove>(
        "MembershipImprove",
        (sp, key) => new MembershipImprove(
            "Fahad",
            "dev.fahad98@gmail.com",
            "Password"
        )
    );

    //builder.Services.AddScoped<IMembership, MembershipImprove>(s => new MembershipImprove("Full Name", "Email", "Password"));
    #endregion

    #region deoebdency injection through authofac
    //builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    //builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
    //{
    //    containerBuilder.RegisterType<Membership>().As<IMembership>().InstancePerLifetimeScope();
    //    containerBuilder.RegisterType<MembershipImprove>().As<IMembership>().InstancePerLifetimeScope();
    //});
    #endregion

    #region Serilog Configuration
    builder.Host.UseSerilog((hostingContext, configuration) => configuration
            .MinimumLevel.Debug()
            .MinimumLevel.Override("Microsoft", Serilog.Events.LogEventLevel.Warning)
            .Enrich.FromLogContext()
            .ReadFrom.Configuration(hostingContext.Configuration)
    );
    //This will read if system is not crashed
    #endregion

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (!app.Environment.IsDevelopment())
    {
        app.UseExceptionHandler("/Home/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();
    app.UseRouting();

    app.UseAuthorization();

    app.MapStaticAssets();

    app.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}")
        .WithStaticAssets();

    Log.Information("Application Starting Up");
    app.Run();
}
catch (Exception e)
{
    Log.Fatal(e, "Application terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}