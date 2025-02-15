using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Repositories
{
    public class SupportProfileRepository(DataBaseContext dataBaseContext) : ISupportProfileRepository
    {
        private readonly DataBaseContext DataBaseContext = dataBaseContext;
        public int Create(SupportProfile entity)
        {
            DataBaseContext.Add(entity);
            return DataBaseContext.SaveChanges();
        }

        public int Delete(string id)
        {
            var entity = DataBaseContext.SupportProfiles.FirstOrDefault(x => x.Id == id);
            if (entity is null)
                throw new ArgumentException($"The support profile with id {id} wasn't found");
            DataBaseContext.Remove(entity);
            return DataBaseContext.SaveChanges();
        }

        public IQueryable<SupportProfile> GetAll()
        {
            return DataBaseContext.SupportProfiles.AsNoTracking();
        }

        public IQueryable<SupportProfile> GetAllWithIncludedEntities()
        {
            return DataBaseContext.SupportProfiles.Include(x => x.Support).AsNoTracking();
        }

        public SupportProfile? GetById(string id)
        {
            return DataBaseContext.SupportProfiles.FirstOrDefault(x => x.Id == id);
        }

        public SupportProfile? GetByIdWithIncludedEntities(string id)
        {
            return DataBaseContext.SupportProfiles.Include(x => x.Support).FirstOrDefault(x => x.Id == id);
        }

        public int Update(SupportProfile entity)
        {
            DataBaseContext.Update(entity);
            return DataBaseContext.SaveChanges();
        }
    }
}
