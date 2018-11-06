using System;
using System.Data.SqlClient;
using System.Threading.Tasks;

using Identity.Infrastructure;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

using Polly;

namespace Identity.API.Infrastructure
{
    public class IdentityContextSeed
    {
        public async Task SeedAsync(IdentityContext context, ILogger<IdentityContextSeed> logger)
        {
            var policy = CreatePolicy(logger, nameof(IdentityContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();

                    await context.SaveChangesAsync();
                }
            });
        }

        private Policy CreatePolicy(ILogger<IdentityContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogTrace($"[{prefix}] Exception {exception.GetType().Name} with message ${exception.Message} detected on attempt {retry} of {retries}");
                    }
                );
        }
    }
}
