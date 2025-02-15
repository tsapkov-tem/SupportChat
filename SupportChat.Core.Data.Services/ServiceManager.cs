using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;

namespace SupportChat.Core.Data.Services
{
    public class ServiceManager(DbContextOptions<DataBaseContext> dbContextOptions) : IServiceManager
    {
        private readonly DbContextOptions<DataBaseContext> _dbContextOptions = dbContextOptions;

        public IProblemLogService ProblemLogService => new ProblemLogService(_dbContextOptions);

        public IProblemService ProblemService => new ProblemService(_dbContextOptions);

        public ISupportService SupportService => new SupportService(_dbContextOptions);

        public ISupportProfileService SupportProfileService => new SupportProfileService(_dbContextOptions);
    }
}
