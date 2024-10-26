using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Testcontainers.MsSql;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using InGreed_API;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using InGreed_API.DataContext;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System.Data.Common;
using Microsoft.Data.SqlClient;
using DotNet.Testcontainers.Builders;

namespace InGreed_API_IntegrationTest_.Utility
{
    public class IntegrationTestWebAppFactory : WebApplicationFactory<Startup>, IAsyncLifetime
    {
        const string Username = "sa";
        const string Password = "Strong_password_123!";
        const int MssqlContainerPort = 1433;

        private readonly MsSqlContainer _dbContainer = new MsSqlBuilder()
           
            .WithImage("mcr.microsoft.com/mssql/server:2022-latest")
            .WithPassword(Password)
            .WithPortBinding(MssqlContainerPort, true)
            .WithEnvironment("ACCEPT_EULA", "Y")
            .WithEnvironment("MSSQL_SA_PASSWORD", Password)
            .WithWaitStrategy(Wait.ForUnixContainer().UntilCommandIsCompleted("/opt/mssql-tools/bin/sqlcmd", "-S", $"localhost,{MssqlContainerPort}", "-U", Username, "-P", Password))
            .Build();

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureTestServices(services =>
            {
                var descriptor = services
                 .SingleOrDefault(s => s.ServiceType == typeof(DbContextOptions<InGreedDataContext>));

                if (descriptor is not null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<InGreedDataContext>(options =>
                    options.UseSqlServer(_dbContainer.GetConnectionString()));
            });

        }
        public Task InitializeAsync()
        {
            return _dbContainer.StartAsync();
        }

        public new Task DisposeAsync()
        {
            return _dbContainer.StopAsync();
        }
    }
}
