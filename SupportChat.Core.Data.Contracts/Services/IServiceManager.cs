namespace SupportChat.Core.Data.Contracts.Services
{
    public interface IServiceManager
    {
        IProblemLogService ProblemLogService { get; }
        IProblemService ProblemService { get; }
        ISupportService SupportService { get; }
        ISupportProfileService SupportProfileService { get; }
    }
}
