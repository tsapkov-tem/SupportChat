using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Repositories;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Services
{
    public abstract class BaseService<TEntity> : IBaseService<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly DbContextOptions<DataBaseContext> DbContextOptions;
        private readonly  IBaseRepository<TEntity> _repository;

        protected BaseService(DbContextOptions<DataBaseContext> dbContextOptions, IBaseRepository<TEntity> baseRepository)
        {
            DbContextOptions = dbContextOptions;
            _repository = baseRepository;
        }

        public TEntity Create(TEntity entity)
        {
            try
            {
                using var dbContext = new DataBaseContext(DbContextOptions);

                var result = _repository.Create(entity);
                if (result == 0)
                    throw new Exception($"Unable to create {typeof(TEntity)} in database.");
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception($"Error during database update: {ex.Message}");
            }
        }

        public void Delete(string id)
        {
            try
            {
                using var dbContext = new DataBaseContext(DbContextOptions);

                var result = _repository.Delete(id);
                if(result == 0) 
                    throw new Exception($"Unable to delete {typeof(TEntity)} in database.")
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception($"Error during database update: {ex.Message}");
            }
        }

        public TEntity? GetById(string id)
        {
            try
            {
                using var dbContext = new DataBaseContext(DbContextOptions);

                var result = _repository.GetById(id);
                if (result is null)
                    throw new Exception($"{typeof(TEntity)} was not found in the database with id: {id}");

                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception($"Error during database update: {ex.Message}");
            }
        }

        public TEntity Update(TEntity entity)
        {
            try
            {
                using var dbContext = new DbContext(DbContextOptions);

                var result = _repository.Update(entity);
                if (result == 0)
                    throw new Exception($"Unable to update {typeof(TEntity)} in database.");
                return entity;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                throw new Exception($"Error during database update: {ex.Message}");
            }
        }
    }
}
