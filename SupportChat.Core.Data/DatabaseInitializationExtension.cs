using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SupportChat.Core.Data.Entities;

namespace SupportChat.Core.Data
{
    public static class DatabaseInitializationExtension
    {
        public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            string? provider = configuration.GetSection(ConfigurationKeyConstants.CONNECTION_PROVIDER).Value;
            if (string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("Database provider is undefined.");

            var dbContextOptions = DbContextOptionFactory.GetContextOptions(configuration);
            
            services.AddSingleton(dbContextOptions);
            services.AddScoped(context => new DataBaseContext(context.GetRequiredService<DbContextOptions<DataBaseContext>>()));
        }
    }
}
