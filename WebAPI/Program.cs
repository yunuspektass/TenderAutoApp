
using System.Text;
using System.Text.Json.Serialization;
using AutoMapper;
using Business.GenericRepository.BaseRep;
using Business.GenericRepository.BaseServices;
using Business.GenericRepository.ConcManager;
using Business.GenericRepository.ConcRep;
using Business.Mapper;
using Core.Domain.Enums;
using Core.Services.ServiceClasses;
using Core.Services.ServiceManager;
using Core.Services.ServiceSettings;
using DataAccess;
using DataAccess.SeedData;
using Domain.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<TenderAutoAppContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("TenderAutoAppContext"));
});

var mapperConfiguration = new MapperConfiguration(mc =>
{
mc.AddMaps("Business");
});

var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);



builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICompanyTenderService, CompanyTenderManager>();
builder.Services.AddScoped<ITenderProductService, TenderProductManager>();
builder.Services.AddScoped<ITenderProductListService, TenderProductListManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICompanyService, CompanyManager>();
builder.Services.AddScoped<INotificationService, NotificationManager>();
builder.Services.AddScoped<IOfferService , OfferManager>();
builder.Services.AddScoped<IProductService , ProductManager>();
builder.Services.AddScoped<ITenderService, TenderManager>();
builder.Services.AddScoped<IUnitService, UnitManager>();
builder.Services.AddScoped<IUserService , UserManager>();
builder.Services.AddScoped<IHashingService , HashingManager>();
builder.Services.AddScoped<IUserAuthenticationService, UserAuthenticationManager>();
builder.Services.AddScoped<IRoleService, RoleManager>();
builder.Services.AddScoped<IPermissionService,PermissionManager>();
builder.Services.AddScoped<IRolePermissionService, RolePermissionManager>();
builder.Services.AddScoped<IUserRoleService , UserRoleManager>();
builder.Services.AddScoped<IUserTenderService, UserTenderManager>();
builder.Services.AddScoped<IUserCompanyService, UserCompanyManager>();
builder.Services.AddScoped<UserRoleRepository>();
builder.Services.AddScoped<RolePermissionRepository>();
builder.Services.AddScoped<PermissionRepository>();
builder.Services.AddScoped<RoleRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<CompanyRepository>();
builder.Services.AddScoped<NotificationRepository>();
builder.Services.AddScoped<OfferRepository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<TenderRepository>();
builder.Services.AddScoped<UnitRepository>();
builder.Services.AddScoped<CategoryRepository>();
builder.Services.AddScoped<CompanyTenderRepository>();
builder.Services.AddScoped<TenderProductRepository>();
builder.Services.AddScoped<TenderProductListRepository>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddScoped<UserTenderRepository>();
builder.Services.AddScoped<UserCompanyRepository>();
builder.Services.AddTransient<IMailService, MailManager>();
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));

builder.Services.AddControllers();

builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});



builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "TenderAutoApp",
        Version = "v1"
    });
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 1safsfsdfdfd\"",
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement {
        {
            new OpenApiSecurityScheme {
                Reference = new OpenApiReference {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.RequireHttpsMetadata = true;
    o.SaveToken = true;
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});


builder.Services.AddAuthorization();


builder.Services.AddControllers().AddJsonOptions(options =>
{
 options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.Preserve;
});

builder.Services.AddCors(options =>
{
  options.AddPolicy("AllowAllOrigins", policy =>
  {
    policy
      .AllowAnyOrigin()
      .AllowAnyHeader()
      .AllowAnyMethod();
  });
});

builder.Services.AddHttpContextAccessor();


var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<TenderAutoAppContext>();
        context.Database.Migrate();
        SeedData.Initialize(services);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Veritabanı migration veya seed işlemi sırasında bir hata oluştu.");
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

//NSwag'ı JSON endpoint olarak sunmak için middleware etkinleştirdik
app.UseOpenApi();

//NSwag'ı UI'yi web de sunmak için middleware etkinleştirdik
//NSwag JSON endpoint'ini belirt


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "TenderAutoApp v1");
    c.RoutePrefix = string.Empty; // Swagger'ı root'ta çalıştırmak için
});


app.UseCors("AllowAllOrigins");
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapControllers();

var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
