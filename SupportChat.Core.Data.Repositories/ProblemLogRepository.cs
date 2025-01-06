using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Repositories
{
    public class ProblemLogRepository(DataBaseContext dataBaseContext) : IProblemLogRepository
    {
        private readonly DataBaseContext DataBaseContext = dataBaseContext;

        public int Create(ProblemLog entity)
        {
            DataBaseContext.ProblemLogs.Add(entity);
            return DataBaseContext.SaveChanges();
        }

        public int Delete(string id)
        {
            var entity = DataBaseContext.ProblemLogs.FirstOrDefault(x => x.Id == id);
            if (entity is null)
                throw new ArgumentException($"The problem log with id {id} wasn't found");
            DataBaseContext.ProblemLogs.Remove(entity);
            return DataBaseContext.SaveChanges();
        }

        public IQueryable<ProblemLog> GetAll()
        {
            return DataBaseContext.ProblemLogs.AsNoTracking();
        }

        public IQueryable<ProblemLog> GetAllWithIncludedEntities()
        {
            return DataBaseContext.ProblemLogs.Include(x => x.Support).AsNoTracking();
        }

        public ProblemLog? GetById(string id)
        {
            return DataBaseContext.ProblemLogs.FirstOrDefault(x => x.Id == id);
        }

        public ProblemLog? GetByIdWithIncludedEntities(string id)
        {
            return DataBaseContext.ProblemLogs.Include(x => x.Support).FirstOrDefault(x => x.Id == id);
        }

        public int Update(ProblemLog entity)
        {
            DataBaseContext.ProblemLogs.Update(entity);
            return DataBaseContext.SaveChanges();
        }
    }
}
