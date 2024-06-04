using assembly.Wrapper.Response;
using assembly.ViewModel;
//using grpc.Services;

namespace assembly.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient 
{
    Task<ResponseWrapperViewModel<CounterViewModel>>DoCreate(string arg);
}

public class gRpcCounterServiceClient
{
    public async Task<ResponseWrapperViewModel<CounterViewModel>>DoCreate(string arg)
    {
        CreateRequest request=new CreateRequest(); // CreateRequest provient du services gRpc
        var responseServer = await Server.DoCreate(request); // Server également 
        var responseEffet = ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));
        
        return responseEffet;
    }
}
