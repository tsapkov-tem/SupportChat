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
    }
}
