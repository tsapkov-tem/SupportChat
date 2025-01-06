using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Contracts.Repositories
{
    public interface IBaseRepository<T> where T : IEntity
    {
        public T? GetById(string id);
        public IQueryable<T> GetAll();
        public IQueryable<T> GetAllWithIncludedEntities();
        public T? GetByIdWithIncludedEntities(string id);
        public int Create(T entity);
        public int Update(T entity);
        public int Delete(string id);
    }
}
