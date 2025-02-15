using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;
using SupportChat.Core.Data.Repositories;

namespace SupportChat.Core.Data.Services
{
    public class SupportService(DbContextOptions<DataBaseContext> dbContextOptions)
        : BaseService<Support>(dbContextOptions, new SupportRepository(new DataBaseContext(dbContextOptions))), ISupportService
    {
    }
}
