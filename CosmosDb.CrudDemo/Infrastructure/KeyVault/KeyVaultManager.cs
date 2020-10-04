using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using CosmosDb.CrudDemo.Infrastructure.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosDb.CrudDemo.Infrastructure.KeyVault
{
    public class KeyVaultManager
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger _logger;

        public KeyVaultManager(IConfiguration configuration, ILogger<KeyVaultManager> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string GetValue(string key, string localKey = null)
        {
            if (localKey is null)
                localKey = key;

            if (EnvironmentChecker.IsDevelopmentEnvironment())
            {
                _logger.LogInformation("KeyVaultManager: Development environment configuration");
                return _configuration[localKey];
            }


            _logger.LogInformation("KeyVaultManager: Production environment configuration");
            SecretClientOptions options = new SecretClientOptions()
            {
                Retry =
                    {
                        Delay= TimeSpan.FromSeconds(2),
                        MaxDelay = TimeSpan.FromSeconds(16),
                        MaxRetries = 5,
                        Mode = RetryMode.Exponential
                    }
            };
            var client = new SecretClient(new Uri("https://kv-rnd-vault.vault.azure.net/"), new DefaultAzureCredential(), options);

            KeyVaultSecret secret = client.GetSecret(key);

            string secretValue = secret.Value;
            return secretValue;
        }
    }
}
