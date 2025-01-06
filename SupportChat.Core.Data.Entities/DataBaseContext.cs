using Microsoft.EntityFrameworkCore;
using SupportChat.Core.Data.Entities.Models;

namespace SupportChat.Core.Data.Entities
{
    public class DataBaseContext : DbContext
    {
        public DbSet<Problem> Problems { get; set; }
        public DbSet<ProblemLog> ProblemLogs { get; set; }
        public DbSet<Support> Supports { get; set; }
        public DbSet<SupportProfile> SupportProfiles { get; set; }
        public DataBaseContext(DbContextOptions options) : base(options) { }
        public DataBaseContext() { }
    }
}
