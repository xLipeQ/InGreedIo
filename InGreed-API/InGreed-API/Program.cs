using InGreed_API;
using InGreed_API.DataContext;
using InGreed_API.Models;
using InGreed_API.Services.AuthService;
using InGreed_API.Services.Ingredients;
using InGreed_API.Services.JwtService;
using InGreed_API.Services.OpinionService;
using InGreed_API.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var startup = new Startup();

startup.ConfigureServices(builder.Services, builder.Logging, builder.Configuration);

var app = builder.Build();

startup.Configure(app, builder.Environment, builder.Configuration);

app.Run();
