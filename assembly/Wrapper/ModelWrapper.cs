using assembly.Wrapper.Response;

namespace assembly.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient 
{
    Task<ResponseWrapperViewModel<CounterViewModel>>DoCreate(string arg);
}

public class gRpcCounterServiceClient
{
    public async Task<ResponseWrapperViewModel<CounterViewModel>>DoCreate(string arg)
    {
        CreateRequest request=new CreateRequest();
        var responseServer = await Server.DoCreate(request);
        var responseEffet = ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));

        return responseEffet;
    }
}
