using Microsoft.EntityFrameworkCore;
using SiteManangmentAPI.Base.Logger;
using SiteManangmentAPI.Data.DBContext;
using SiteManangmentAPI.Data.Repository;
using System.Reflection;
using SiteManangmentAPI.Business.Services;
using SiteManangmentAPI.Web.Middlewares;
using SiteManangmentAPI.Data.UnitOfWork;
using SiteManangmentAPI.Business.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//dbContext
var dbType = builder.Configuration.GetConnectionString("DbType");
if (dbType == "MsSql")
{
    builder.Services.AddDbContext<SimDbContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("MsSqlConnection")));
}

// Repository register
builder.Services.AddScoped<IApartmentRepository, ApartmentRepository>();
builder.Services.AddScoped<IBillingRepository, BillingRepository>();
builder.Services.AddScoped<IContactRepository, ContactRepository>();
builder.Services.AddScoped<IMessageRepository, MessageRepository>();
builder.Services.AddScoped<IPaymentRepository, PaymentRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

// Mapper register
builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MapperProfile)));


// Logger register
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

//UnitOfWork register
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Custom service register
builder.Services.AddScoped<IApartmentService, ApartmentService>();
builder.Services.AddScoped<IBillingService, BillingService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

//Authorization icon
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
    {
        Description = "Standard Authorization header (\"bearer {token}\")",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.OperationFilter<SecurityRequirementsOperationFilter>();
});

//Authentication
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Add middleware to the pipeline 

app.UseCustomExceptionMiddleware(); // This uses the custom extension method

app.UseAuthentication();//
app.UseAuthorization();

app.MapControllers();

app.Run();
