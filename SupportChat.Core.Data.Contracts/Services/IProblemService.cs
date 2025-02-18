using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Contracts.Services
{
    public interface IProblemService : IBaseService<Problem>
    {
        public IEnumerable<Problem> GetAllWithIncludedEntities();
    }
}
