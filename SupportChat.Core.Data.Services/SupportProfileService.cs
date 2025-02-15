using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Entities;
using SupportChat.Core.Data.Entities.Models;
using SupportChat.Core.Data.Repositories;

namespace SupportChat.Core.Data.Services
{
    public class SupportProfileService(DbContextOptions<DataBaseContext> dbContextOptions) 
        : BaseService<SupportProfile>(dbContextOptions, new SupportProfileRepository(new DataBaseContext(dbContextOptions))), ISupportProfileService
    {
    }
}
