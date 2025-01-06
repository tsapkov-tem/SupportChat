using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Contracts.Services
{
    public interface IBaseService<T> where T : IEntity
    {
        public T Add(T entity);
        public T? Get(T entity);
        public T Update(T entity);
        public void Delete(T entity);
    }
}
