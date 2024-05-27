using assembly.Wrapper.ModelWrapper;
using assembly.fluxor.Action;
using Fluxor;

namespace assembly.fluxor;

public class CounterEffet
{
    private IgRpcCounterServiceClient gRpcCounterServiceClient{get;set;}

    public CounterEffet( IgRpcCounterServiceClient server)
    {
        gRpcCounterServiceClient=server;
    }
    [EffectMethod]
    public async Task ExecuteEffet(ActionInput action, IDispatcher dispatcher)
    {
         var responseWrapper = await gRpcCounterServiceClient.CreateTodo(action.Counter);
        
         dispatcher.Dispatch(new ActionOutput(responseWrapper.Content));
    }

}
