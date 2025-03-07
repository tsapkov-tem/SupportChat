using SupportChat.API;
using SupportChat.Core.Data;
using SupportChat.Core.Data.Contracts.Services;
using SupportChat.Core.Data.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddGrpc();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddScoped<IServiceManager, ServiceManager>();

var app = builder.Build();

app.MapGrpcService<ChatServiceApi>();

app.Run();
