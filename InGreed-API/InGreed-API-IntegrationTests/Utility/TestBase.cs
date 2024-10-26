using InGreed_API.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InGreed_API_IntegrationTest_.Utility
{
    public class TestBase : IClassFixture<IntegrationTestWebAppFactory>, IDisposable
    {
        private readonly IServiceScope _scope;
        protected readonly InGreedDataContext DbContext;

        protected TestBase(IntegrationTestWebAppFactory factory)
        {
            _scope = factory.Services.CreateScope();

            DbContext = _scope.ServiceProvider
                .GetRequiredService<InGreedDataContext>();

            DbContext.Database.Migrate();
        }

        public void Dispose()
        {
            _scope?.Dispose();
            DbContext?.Dispose();
        }
    }
}
