using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Repositories
{
    public class SupportRepository(DataBaseContext dataBaseContext) : ISupportRepository
    {
        private readonly DataBaseContext DataBaseContext = dataBaseContext;
        public int Create(Support entity)
        {
            DataBaseContext.Supports.Add(entity);
            return DataBaseContext.SaveChanges();
        }

        public int Delete(string id)
        {
            var entity = DataBaseContext.Supports.FirstOrDefault(x => x.Id == id);
            if (entity is null)
                throw new ArgumentException($"The support with id {id} wasn't found");
            DataBaseContext.Supports.Remove(entity);
            return DataBaseContext.SaveChanges();
        }

        public IQueryable<Support> GetAll()
        {
            return DataBaseContext.Supports.AsNoTracking();
        }

        public IQueryable<Support> GetAllWithIncludedEntities()
        {
            return DataBaseContext.Supports.Include(x => x.SupportProfile).AsNoTracking();
        }

        public Support? GetById(string id)
        {
            return DataBaseContext.Supports.FirstOrDefault(x => x.Id == id);
        }

        public Support? GetByIdWithIncludedEntities(string id)
        {
            return DataBaseContext.Supports.Include(x => x.SupportProfileId).FirstOrDefault(x => x.Id == id);
        }

        public int Update(Support entity)
        {
            DataBaseContext.Update(entity);
            return DataBaseContext.SaveChanges();
        }
    }
}
