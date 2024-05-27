using assembly.ViewModel;
using Fluxor;

namespace assembly.Fluxor;

[FeatureState]
public record class CounterState
{
    public ResultResponseViewModel ?response {get;set;}
    public CounterState()
    {
        response = new ResultResponseViewModel();
    }

}
