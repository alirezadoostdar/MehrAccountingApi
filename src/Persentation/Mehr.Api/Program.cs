using Mehr.Api.Middlewares;
using Mehr.Application;
using Mehr.Application.Costs;
using Mehr.Application.Costs.Contracts;
using Mehr.Application.DetailedAccounts;
using Mehr.Application.DetailedAccounts.Contracts;
using Mehr.Application.Intrefaces;
using Mehr.Application.Services;
using Mehr.Application.Zones;
using Mehr.Application.Zones.Contracts;
using Mehr.Domain.Interfaces;
using Mehr.Domain.Interfaces.Costs;
using Mehr.Domain.Interfaces.DetailedAccounts;
using Mehr.Infarstructure;
using Mehr.Infarstructure.Costs;
using Mehr.Infarstructure.DetailedAccounts;
using Mehr.Infarstructure.Repositories.Stocks;
using Mehr.Infarstructure.Zones;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("MehrConnectionString"),
        x => x.UseNetTopologySuite());
});



builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDetailedAccountRepository, EfDetailedAccountRepository>();
builder.Services.AddScoped<IDetailedAccountService, DetailedAccountService>();

builder.Services.AddScoped<ICostRepository, EfCostRepository>();
builder.Services.AddScoped<ICostService, CostService>();

builder.Services.AddScoped<IProductCategoryRepository, EfProductCategoryRepository>();
builder.Services.AddScoped<IZoneRepository, EfZoneRepository>();

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IZoneService, ZoneService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

