using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;
using SupportChat.Core.Data.Repositories;

namespace SupportChat.Core.Data.Services
{
    public class ProblemLogService(DbContextOptions<DataBaseContext> dbContextOptions)
        : BaseService<ProblemLog>(dbContextOptions, new ProblemLogRepository(new DataBaseContext(dbContextOptions))), IProblemLogService
    {
    }
}
