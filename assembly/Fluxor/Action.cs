﻿using assembly.ViewModel;

namespace assembly.fluxor.Action;

public class ActionOutput 
{
    public ResultResponseViewModel ?ResponseServer;
    public CounterViewModel ?Content {get;}

    public ActionOutput(ResultResponseViewModel responseServer)
    {
        ResponseServer = responseServer;   
    }
    public ActionOutput(CounterViewModel content)
    {
        Content=content;
    }
}

public class ActionInput
{
        public string Counter {get;set;}

        public ActionInput(string counter)
        {
            Counter = counter;
        }
}
    

