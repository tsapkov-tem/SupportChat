using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;
using SupportChat.Core.Data.Repositories;

namespace SupportChat.Core.Data.Services
{
    public class ProblemService(DbContextOptions<DataBaseContext> dbContextOptions)
        : BaseService<Problem>(dbContextOptions, new ProblemRepository(new DataBaseContext(dbContextOptions))), IProblemService
    {
        public IEnumerable<Problem> GetAllWithIncludedEntities()
        {
            try
            {
                using var dbContext = new DataBaseContext(DbContextOptions);
                var repository = new ProblemRepository(dbContext);
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
