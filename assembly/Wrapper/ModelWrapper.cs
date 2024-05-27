using assembly.Wrapper.Response;
namespace assembly.Wrapper.ModelWrapper;

public interface IgRpcCounterServiceClient 
{
    Task<ResponseWrapperViewModel<CounterViewModel>>CreateTodo(string arg);
}

public class gRpcCounterServiceClient
{
    // Task<ResponseWrapperViewModel<CounterViewModel>>CreateTodo(string arg)
    // {
    //     CreateTodoRequest request=new CreateTodoRequest();
    //     var responseServer = await grpc.CreateTodo(request);
    //     var responseEffet = ResponseWrapperViewModel<CounterViewModel>.Create(responseServer,dto => new CounterViewModel(dto));
        
    //     await ProcessMessages(responseEffet);
        
    //     return responseEffet;
    // }
}
