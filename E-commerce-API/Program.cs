using ECommerce.API;
using ECommerce.API.Data.IRepos;
using ECommerce.API.Data.Repos;
using ECommerce.API.Helpers;
using ECommerce.API.Helpers.PriceFilterStrategy;
using ECommerce.API.Models.Identity;
using ECommerce.API.Server.Database;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// For Entity Framework
builder.Services.AddDbContext<DataContext>(options => options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));



// For Identity
builder.Services.AddIdentity<AppUser, AppRole>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequiredLength = 5;
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = true;
    options.Password.RequireUppercase = false;
})
.AddEntityFrameworkStores<DataContext>()
.AddDefaultTokenProviders();


builder.Services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", policyBuilder => policyBuilder
                        .WithOrigins("http://localhost:4200", "https://localhost:4200", "http://localhost:8081", "http://localhost:8080",
                            "http://localhost:8082")
                        .SetIsOriginAllowed(origin => true)
                        .SetIsOriginAllowedToAllowWildcardSubdomains()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

// services.AddCors(options =>
//             options.AddPolicy("EnableCors", builder =>
//                 builder.SetIsOriginAllowed(origin => true).AllowAnyMethod().AllowAnyHeader().AllowCredentials()));

// Adding Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddMvc().AddNewtonsoftJson();

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IAppUserRepository, AppUserRepository>();
builder.Services.AddScoped<IInvoiceRepository, InvoiceRepository>();
builder.Services.AddScoped<IStatsRepository, StatsRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IImagesUploader, ImagesUploader>();

builder.Services.AddScoped<IProductFilterContext, ProductFilterContext>();
builder.Services.AddScoped<IPriceFilterStrategy, LessThanPriceFilter>();
builder.Services.AddScoped<IPriceFilterStrategy, RangePriceFilter>();
builder.Services.AddScoped<IPriceFilterStrategy, GreaterThanOrEqualPriceFilter>();



//builder.Services.AddTransient<PriceFilterServiceResolver>(serviceProvider => key =>
//{
//    switch (key)
//    {
//        case SortType.LessThan:
//            return serviceProvider.GetService<LessThanPriceFilter>();
//        case SortType.Range:
//            return serviceProvider.GetService<LessThanPriceFilter>();
//        case SortType.EqualOrGreaterThan:
//            return serviceProvider.GetService<LessThanPriceFilter>();
//        default:
//            return serviceProvider.GetService<GreaterThanPriceFilter>();
//    }
//});

var app = builder.Build();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedProto
});

app.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



app.UseHttpsRedirection();


app.UseCors("CorsPolicy");
app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();


app.Run();

