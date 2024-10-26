using InGreed_API.DataContext;
using InGreed_API.Hubs;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.CacheService.cs;
using InGreed_API.Services.CategoryService;
using InGreed_API.Services.Ingredients;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.LogService;
using InGreed_API.Services.OpinionService;
using InGreed_API.Services.PreferenceService;
using InGreed_API.Services.ProductService;
using InGreed_API.Services.ReportService;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

namespace InGreed_API
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services, ILoggingBuilder logging, IConfiguration configuration)
        {
            services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
                {
                    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey
                });

                options.OperationFilter<SecurityRequirementsOperationFilter>();
            });

            // Jwt authenticaiton
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = configuration.GetSection("Audiences:api").Value,
                    ValidAudiences = new List<string>()
                    {
                        configuration.GetSection("Audiences:api").Value,
                        configuration.GetSection("Audiences:gui").Value
                    },

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetSection("SecretKeys:JwtSecretKey").Value))
                };
            });

            // Database
            services.AddDbContext<InGreedDataContext>(options => options.UseSqlServer(
                    configuration.GetConnectionString("InGreedConnectionString")));

            // Cors
            services.AddCors(options =>
            {
                options.AddPolicy("defaultCorsPolicy", builder =>
                {
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .SetIsOriginAllowed((host) => true)
                           .AllowCredentials();
                });
            });
            // SignalR
            services.AddSignalR();

            // Services
            services.AddTransient<IPasswordHasher<User>, PasswordHasher<User>>();
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IJwtService, JwtService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IOpinionService, OpinionService>();
            services.AddTransient<IPreferenceService, PreferenceService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IIngredientService, IngredientService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<IReportService, ReportService>();
            services.AddTransient<ILogService, LogService>();
        }

        public void Configure(WebApplication app, IWebHostEnvironment env, IConfiguration configuration)
        {
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors("defaultCorsPolicy");

            app.UseAuthentication();

            app.UseAuthorization();
            app.MapControllers();

            app.MapHub<SignalrHub>(configuration.GetSection("SignalrHubPath").Value);
        }
    }
}
