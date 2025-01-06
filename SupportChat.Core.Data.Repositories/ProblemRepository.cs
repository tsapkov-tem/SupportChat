using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Repositories
{
    public class ProblemRepository(DataBaseContext dataBaseContext) : IProblemRepository
    {
        private readonly DataBaseContext DataBaseContext = dataBaseContext;
        public int Create(Problem entity)
        {
            DataBaseContext.Add(entity);
            return DataBaseContext.SaveChanges();
        }

        public int Delete(string id)
        {
            var entity = DataBaseContext.Problems.FirstOrDefault(x => x.Id == id);
            if (entity is null)
                throw new ArgumentException($"The problem with {id} wasn't found");
            DataBaseContext.Problems.Remove(entity);
            return DataBaseContext.SaveChanges();
        }

        public IQueryable<Problem> GetAll()
        {
            return DataBaseContext.Problems.AsNoTracking();
        }

        public IQueryable<Problem> GetAllWithIncludedEntities()
        {
            return DataBaseContext.Problems.Include(x => x.ProblemLogs).AsNoTracking();
        }

        public Problem? GetById(string id)
        {
            return DataBaseContext.Problems.FirstOrDefault(x => x.Id == id);
        }

        public Problem? GetByIdWithIncludedEntities(string id)
        {
            return DataBaseContext.Problems.Include(x => x.ProblemLogs).FirstOrDefault(x => x.Id == id);
        }

        public int Update(Problem entity)
        {
            DataBaseContext.Update(entity);
            return DataBaseContext.SaveChanges();
        }
    }
}
