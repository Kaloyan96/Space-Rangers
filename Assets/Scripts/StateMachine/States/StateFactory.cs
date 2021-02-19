using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateFactory //It belongs to the people
{
    public const string idle_name = "Idle";
    public const string moving_name = "Moving";
    public const string interupt_name = "Interupt";
    
    public static State createState_Idle()
    {
        string stateName = idle_name;

        State res = ScriptableObject.CreateInstance<State>();
        res.init(stateName);

        res.Transitions.Add(new Transition(ScriptableObject.CreateInstance<ShouldMove>(), moving_name, null));

        return res;
    }
    public static State createState_Moving()
    {
        string stateName = moving_name;

        State res = ScriptableObject.CreateInstance<State>();
        res.init(stateName);

        res.EntryActions.Add(ScriptableObject.CreateInstance<MoveToDestinationAction>());
        
        res.Transitions.Add(new Transition(ScriptableObject.CreateInstance<DestinationReached>(), idle_name, null));

        return res;
    }

    public static State createState_Interupting()
    {
        string stateName = interupt_name;

        State res = ScriptableObject.CreateInstance<State>();
        res.init(stateName);

        res.EntryActions.Add(ScriptableObject.CreateInstance<StopMoving>());

        res.ExitActions.Add(ScriptableObject.CreateInstance<FinishInterupt>());

        res.Transitions.Add(new Transition(ScriptableObject.CreateInstance<AlwaysTrue>(), idle_name, null));

        return res;
    }


}
