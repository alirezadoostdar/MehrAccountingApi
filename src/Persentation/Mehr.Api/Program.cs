using Mehr.Api.Authorization;
using Mehr.Api.Middlewares;
using Mehr.Application;
using Mehr.Application.ApiValidate;
using Mehr.Application.ApiValidate.Contracts;
using Mehr.Application.Costs;
using Mehr.Application.Costs.Contracts;
using Mehr.Application.DetailedAccounts;
using Mehr.Application.DetailedAccounts.Contracts;
using Mehr.Application.Docs;
using Mehr.Application.Docs.Contracts;
using Mehr.Application.FinancialYears;
using Mehr.Application.FinancialYears.Contracts;
using Mehr.Application.Intrefaces;
using Mehr.Application.Localizations;
using Mehr.Application.Services;
using Mehr.Application.Stocks;
using Mehr.Application.Stocks.Contracts;
using Mehr.Application.Users;
using Mehr.Application.Users.Contracts;
using Mehr.Application.Zones;
using Mehr.Application.Zones.Contracts;
using Mehr.Domain.Docs.Contracts;
using Mehr.Domain.FinancialYears.Contracts;
using Mehr.Domain.Interfaces;
using Mehr.Domain.Interfaces.Costs;
using Mehr.Domain.Interfaces.DetailedAccounts;
using Mehr.Domain.Stocks.Contracts;
using Mehr.Domain.Users.Contracts;
using Mehr.Infarstructure;
using Mehr.Infarstructure.Costs;
using Mehr.Infarstructure.DetailedAccounts;
using Mehr.Infarstructure.Docs;
using Mehr.Infarstructure.FinancialYears;
using Mehr.Infarstructure.Repositories.Stocks;
using Mehr.Infarstructure.Stocks;
using Mehr.Infarstructure.Users;
using Mehr.Infarstructure.Zones;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Globalization;
using System.Text;

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

builder.Services.AddLocalization(options => options.ResourcesPath = "Mehr.Resources");

var supportedCultures = new[] { new CultureInfo("en"), new CultureInfo("fa") };

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    options.DefaultRequestCulture = new RequestCulture("en-US");
    options.SupportedCultures = supportedCultures;
    options.SupportedUICultures = supportedCultures;
    options.AddInitialRequestCultureProvider(new QueryStringRequestCultureProvider());
    options.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider());
});
#region Authentication
builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = "Jwt:Issuer",
            ValidAudience = "Jwt:Audience",
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("c0d0cd85-f64e-4fcd-8625-c8c37c5bdd85")
            )
        };
    });

#endregion

#region Swagger Configuration
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Mehr Accounting Api",
        Description = "ASP.NET Core 8.0 Web API"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                          new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                }
                            },
                            new string[] {}
                    }
                });
});
#endregion

builder.Services.AddAuthorization();
builder.Services.AddSingleton<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, PermissionPolicyProvider>();

builder.Services.AddScoped<ILocalizationService, LocalizationService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddScoped<IDetailedAccountRepository, EfDetailedAccountRepository>();
builder.Services.AddScoped<IDetailedAccountService, DetailedAccountService>();

builder.Services.AddScoped<ICostRepository, EfCostRepository>();
builder.Services.AddScoped<ICostService, CostService>();

builder.Services.AddScoped<IProductCategoryRepository, EfProductCategoryRepository>();
builder.Services.AddScoped<IZoneRepository, EfZoneRepository>();

builder.Services.AddScoped<IProductCategoryService, ProductCategoryService>();
builder.Services.AddScoped<IZoneService, ZoneService>();

builder.Services.AddScoped<IDocRepository, EfDocRepository>();
builder.Services.AddScoped<IDocService, DocService>();

builder.Services.AddScoped<IFinancialYearRepositrory, EfFinancialYearRepository>();
builder.Services.AddScoped<IFinancialYearService, FinancialYearsService>();

builder.Services.AddScoped<IProductRepository, EfProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddScoped<IUserRepository, EfUserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IRoleRepository, EfRoleRepository>();

builder.Services.AddScoped<IApiValidateService, ApiValidateService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

