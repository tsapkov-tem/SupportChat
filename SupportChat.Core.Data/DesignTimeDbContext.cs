using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SupportChat.Core.Data.Entities;

namespace SupportChat.Core.Data
{
    public class DesignTimeDbContext : IDesignTimeDbContextFactory<DataBaseContext>
    {
        public DataBaseContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false)
                .AddEnvironmentVariables()
                .AddCommandLine(args).Build();

            var options = DbContextOptionFactory.GetContextOptions(configuration);
            return new DataBaseContext(options);
        }
    }
}
