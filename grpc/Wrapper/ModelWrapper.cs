using assembly.Wrapper.Response;
using grpc.Services;

namespace assembly.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient 
{
    Task<ResponseWrapperViewModel<CounterViewModel>>FirstWrapper(string arg);
}

public class gRpcCounterServiceClient
{
    // Task<ResponseWrapperViewModel<CounterViewModel>>FirstWrapper(string arg)
    // {
    //     CreateRequest request=new CreateRequest();
    //     var responseServer = await grpc.DoCreate(request);
    //     var responseEffet = ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));
        
    //     await ProcessMessages(responseEffet);
        
    //     return responseEffet;
    // }
}
