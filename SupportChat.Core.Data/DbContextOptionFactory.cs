using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SupportChat.Core.Data.Entities;

namespace SupportChat.Core.Data
{
    public class DbContextOptionFactory
    {
        private static readonly Dictionary<string, Action<DbContextOptionsBuilder, IConfiguration>> OptionFactoryLookup = new(StringComparer.OrdinalIgnoreCase)
        {
            [ConfigurationKeyConstants.PROVIDER_TEMPDB] = SetupSqliteTempDbConnection,
            [ConfigurationKeyConstants.PROVIDER_TESTDB] = SetupSqliteTempDbConnection,
        };

        public static DbContextOptions<DataBaseContext> GetContextOptions(IConfiguration configuration)
        {
            string? provider = configuration.GetSection(ConfigurationKeyConstants.CONNECTION_PROVIDER).Value;

            if (string.IsNullOrEmpty(provider))
                throw new ArgumentNullException("Data provider is undefined.");

            if (!OptionFactoryLookup.TryGetValue(provider, out var optionsFactory))
                throw new NotSupportedException("Data provider is not supported.");

            var optionsBuilder = new DbContextOptionsBuilder<DataBaseContext>();
            optionsFactory(optionsBuilder, configuration);

#if DEBUG
            optionsBuilder.LogTo(Console.Write, LogLevel.Information);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.EnableDetailedErrors();
#endif
            return optionsBuilder.Options;
        }

        private static void SetupSqliteTempDbConnection(DbContextOptionsBuilder optionsBuilder, IConfiguration configuration)
        {
            var dbFilePath = Path.GetTempFileName();
            optionsBuilder.UseSqlite(
                $"Data Source={dbFilePath}",
                b => b.MigrationsAssembly("SupportChat.Core.Data.Migrations.Sqlite")
            );
        }
    }
}
