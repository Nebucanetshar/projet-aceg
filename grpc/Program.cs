using grpc;
using grpc.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGrpc();

var app = builder.Build();
//builder.Services.AddDbContext<AppDbContext>(options => builder.Configuration.GetConnectionString("npgsql"));

app.MapGrpcService<GreeterService>();
app.MapGrpcService<AcegServices>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
