using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
var migrationAssemblyName = typeof(Program).Assembly.FullName;

// Add services to the container.

// builder.Services.AddDbContext<ApplicationDbContext>(options =>
//     options.UseSqlServer(connectionString, b =>
//         b.MigrationsAssembly(migrationAssemblyName)));
// builder.Services.AddDbContext<PlatformDbContext>(options =>
//     options.UseSqlServer(connectionString, b =>
//         b.MigrationsAssembly(migrationAssemblyName)));

builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
{
    // containerBuilder.RegisterModule(new WebModule());
    // containerBuilder.RegisterModule(new MembershipModule(connectionString, migrationAssemblyName));
    // containerBuilder.RegisterModule(new PlatformModule(connectionString, migrationAssemblyName));
});

builder.Host.UseSerilog((ctx, lc) => lc
    .MinimumLevel.Debug()
    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .ReadFrom.Configuration(builder.Configuration));

// builder.Services.AddSingleton<ModeratorDataSeed>();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Application.Api", Version = "v1" });
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Configure the HTTP request pipeline.

try
{
    var app = builder.Build();

    var scope = app.Services.GetAutofacRoot();
    // var moderatorDataSeed = new ModeratorDataSeed();
    // moderatorDataSeed.Resolve(scope);
    // await moderatorDataSeed.SeedUserAsync();

    Log.Information("Application Starting up");

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Application.Api v1"));
    }
    else
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
    }

    app.UseHttpsRedirection();

    app.UseRouting();

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "API start-up failed");
}
finally
{
    Log.CloseAndFlush();
}