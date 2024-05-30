using grpc.Data;
using grpc.Model;
using Grpc.Core;
namespace grpc.Services;

public class Server : Do.DoBase
{
    private readonly AppDbContext _dbContext;

    public Server(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public override async Task<DoCreateResponse>DoCreate(DoCreateRequest request, ServerCallContext context)
    {
        if (request.Title == string.Empty || request.Description == string.Empty)
        throw new RpcException (new Status(StatusCode.InvalidArgument, "une des requêtes est vide"));
        
        var items = new Items
        {
            Title = request.Title,
            Description = request.Description,
        };
        await _dbContext.AddAsync(items);
        await _dbContext.SaveChangesAsync();

        return await Task.FromResult(new DoCreateResponse
        {
            Id=items.Id,
        });
    }
}
