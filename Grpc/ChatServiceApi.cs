using Grpc.Core;
using SupportChat.Core.Data.Contracts.Services;
namespace SupportChat.API
{
    public class ChatServiceApi(IServiceManager serviceManager) : ChatService.ChatServiceBase 
    {
        private readonly IServiceManager _serviceManager = serviceManager;
        public override Task<LogsListResponse> GetLogsList(SupportTypeRequest request, ServerCallContext context)
        {
            try
            {
                var list = _serviceManager.ProblemLogService.GetAllWithIncludedEntities()
                    .Select(x => new ProblemLog() {   
                        Id = x.Id,
                        Code = x.Code,
                        SupportName = x.Support!.SupportName,
                        SupportType = x.Support.SupportType.ToString(),
                        ProblemEvaluation = x.Problem!.ProblemEvaluation.ToString(),
                    });
                var logsList = new LogsList();
                logsList.Logs.AddRange(list);
                var response = new LogsListResponse() { LogList = logsList };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var error = new Error() { Text = ex.Message, Critical = false };
                var errorResponse = new LogsListResponse() { Error = error };
                return Task.FromResult(errorResponse);
            }
        }

        public override Task<ProblemListResponse> GetProblemList(SupportTypeRequest request, ServerCallContext context)
        {
            try
            {
                var list = _serviceManager.ProblemService.GetAllWithIncludedEntities()
                    .Select(x => new Problem()
                    {
                        Id = x.Id,
                        StartMessage = x.StartMessage,
                        ProblemStatus = x.ProblemStatus.ToString(),
                        ProblemEvaluation = x.ProblemEvaluation.ToString()
                    });
                var problemsList = new ProblemList();
                problemsList.Problems.AddRange(list);
                var response = new ProblemListResponse() { ProblemList = problemsList };
                return Task.FromResult(response);
            }
            catch (Exception ex)
            {
                var error = new Error() { Text = ex.Message, Critical = false };
                var errorResponse = new ProblemListResponse() { Error = error };
                return Task.FromResult(errorResponse);
            }
        }
    }
}
