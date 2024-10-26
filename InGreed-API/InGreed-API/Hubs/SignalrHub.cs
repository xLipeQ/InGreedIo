using InGreed_API.Dtos.Requests;
using InGreed_API.Factories;
using InGreed_API.Services.CacheService.cs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Concurrent;

namespace InGreed_API.Hubs
{
    public class SignalrHub : Hub
    {
        private ICacheService cache;

        public SignalrHub(IConfiguration configuration)
        {
            cache = CacheServiceFactory.GetFactory(configuration);
        }

        public override async Task OnConnectedAsync()
        {
            var httpContext = Context.GetHttpContext();
            var userId = httpContext.Request.Query["userId"].ToString();

            if (!string.IsNullOrEmpty(userId))
            {
                cache.SetData($"user_{userId}", Context.ConnectionId);
            }

            await base.OnConnectedAsync();
        }
    }
}
