using assembly.fluxor.Action;
using Fluxor;

namespace assembly.Fluxor;

public static class CounterReduceur
{
    [ReducerMethod]
    public static CounterState ExecuteState(CounterState state, ActionOutput action)
    {
        return state with 
        {
            response = action.ResponseServer
        };
    }
}
