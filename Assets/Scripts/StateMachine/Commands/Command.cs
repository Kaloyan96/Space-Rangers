using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Command
{
    public Predicate Predicate { get; private set; }
    public Dictionary<string, object> Parameters { get; private set; }
    public Command(Predicate predicate, params object[] parameters){
        Predicate = predicate;
        Parameters = new Dictionary<string, object>();
    }
    public virtual bool finished(UnitStateMachine stateMachine)
    {
        return Predicate.Evaluate(stateMachine);
    }
}
