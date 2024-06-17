using assembly.Fluxor;
using common.Wrapper;

//using common.Wrapper.ModelWrapper;
using Fluxor;


namespace assembly.fluxor;

public class CounterEffet
{
    private IgRpcCounterServiceClient gRpcCounterServiceClient;

    public CounterEffet(IgRpcCounterServiceClient server)
    {
        gRpcCounterServiceClient = server;
    }
    [EffectMethod]
    public async Task ExecuteEffet(ActionInput action, IDispatcher dispatcher)
    {
         var responseWrapper = await gRpcCounterServiceClient.DoCreate(action.Counter);
        
         dispatcher.Dispatch(new ActionOutput(responseWrapper.Content));
    }

}
