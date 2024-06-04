using grpc.Data;
using grpc.Model;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;


namespace grpc.Services;

public class Server : Do.DoBase
{
    private readonly AppDbContext _dbContext;
    
    public Server(AppDbContext dbContext)
    {
        _dbContext = dbContext;
       
    }
    #region Création
    public override async Task<CreateResponse>DoCreate(CreateRequest request, ServerCallContext context)
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

        return await Task.FromResult(new CreateResponse
        {
            Id=items.Id,
        });
    }
    #endregion

    #region Lecture
    public override async Task<ReadResponse>DoRead(ReadRequest request, ServerCallContext context)
    {
        if (request.Id<=0)
            throw new RpcException (new Status(StatusCode.InvalidArgument,"l'Id doit être inférieur ou égale a 0")); 
        
           var items= await _dbContext.Items.FirstOrDefaultAsync(o => o.Id == request.Id);
            
            if (items!=null)
            {
                return await Task.FromResult(new ReadResponse{
                    Id=items.Id,
                    Title=items.Title,
                    Description=items.Description,
                });
            }
                throw new RpcException(new Status(StatusCode.NotFound,$"la requête demander n'a pas était trouver{request.Id}"));
    }
    #endregion

    #region Liste
    public override async Task<GetAllResponse>DoList(GetAllRequest request, ServerCallContext context)
    {
        var response= new GetAllResponse();
        var items= await _dbContext.Items.ToListAsync();

        foreach (var item in items)
        {
            response.Id.Add(new ReadResponse{
                Id=item.Id,
                Title=item.Title,
                Description=item.Description,
            });
        }
        return await Task.FromResult(response);
    }
    #endregion

    #region Mise à jour
    public override async Task<UpdateResponse>DoUpdate(UpdateRequest request, ServerCallContext context)
    {
        var items= await _dbContext.Items.FirstOrDefaultAsync(o=>o.Id==request.Id);
        
        if (items!=null)
            throw new RpcException(new Status(StatusCode.NotFound,$"les requêtes générer sont vide{request.Id}"));
        
        items.Title=request.Title;
        items.Description=request.Description;

        await _dbContext.SaveChangesAsync();
        return await Task.FromResult(new UpdateResponse{
            Id=request.Id,
        });
    }
    #endregion

    #region Supprimer
    public override async Task<DeleteResponse>DoDelete(DeleteRequest request, ServerCallContext context)
    {
        if (request.Id<=0)
            throw new RpcException(new Status(StatusCode.InvalidArgument,"ne peut être supprimer si l'id est inférieur ou égale à 0"));

        var items= await _dbContext.Items.FirstOrDefaultAsync(o=> o.Id==request.Id);

        if (items!=null)
            throw new RpcException(new Status(StatusCode.NotFound,$"la requête demander n'a pas était trouver{request.Id}"));

            _dbContext.Remove(items);
            await _dbContext.SaveChangesAsync();

            return await Task.FromResult(new DeleteResponse{
                Id=request.Id,
            });
    }
    #endregion
}
   
