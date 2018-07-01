using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FL.BackgroundHost
{
    internal class TokenRefreshService : BackgroundService
    {
        private readonly ILogger _logger;

        public TokenRefreshService(ILogger<TokenRefreshService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Service starting");

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation(DateTime.Now.ToLongTimeString() + ": Refresh Token!");
                await Task.Delay(15000, stoppingToken);
            }

            _logger.LogInformation("Service stopping");
        }
    }
}
