using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Contracts.Services
{
    public interface IBaseService<T> where T : IEntity
    {
        public T Create(T entity);
        public T? GetById(string id);
        public T Update(T entity);
        public void Delete(string id);
    }
}
