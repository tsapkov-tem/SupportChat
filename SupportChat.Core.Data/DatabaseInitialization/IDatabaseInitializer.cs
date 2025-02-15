using Microsoft.Extensions.Configuration;

namespace SupportChat.Core.Data.DatabaseInitialization
{
    public interface IDatabaseInitializer
    {
        public void InitializeData(IConfiguration configurations);
    }
}
