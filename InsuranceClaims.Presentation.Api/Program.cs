using InsuranceClaims.Application.Common.Interfaces.IServices;
using InsuranceClaims.Application.Common.Interfaces.Persistance;
using InsuranceClaims.Infrastructure;
using InsuranceClaims.Infrastructure.Persistance.DataContext;
using InsuranceClaims.Infrastructure.Persistance.Repositories;
using InsuranceClaims.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(new ConfigurationBuilder()
        .AddJsonFile("appsettings.json")
        .Build())
    .CreateLogger();

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IClaimRepository, ClaimRepository>();

builder.Services.AddScoped<IClaimService, ClaimService>();

builder.Services.AddControllers();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

//using (var scope = app.Services.CreateScope())
//{
//    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
//    await DbSeeder.SeedAsync(dbContext);  // <-- Add await here
//}

app.Run();
