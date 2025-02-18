using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;
using SupportChat.Core.Data.Repositories;

namespace SupportChat.Core.Data.Services
{
    public class ProblemLogService(DbContextOptions<DataBaseContext> dbContextOptions)
        : BaseService<ProblemLog>(dbContextOptions, new ProblemLogRepository(new DataBaseContext(dbContextOptions))), IProblemLogService
    {
        public IEnumerable<ProblemLog> GetAllWithIncludedEntities()
        {
            try
            {
                using var dbContext = new DataBaseContext(DbContextOptions);
                var repository = new ProblemLogRepository(dbContext);
                var result = repository.GetAllWithIncludedEntities().ToList();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception($"Error on querying database: {ex.Message}");
            }
        }
    }
}
