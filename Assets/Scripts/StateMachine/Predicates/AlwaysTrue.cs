using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlwaysTrue : Predicate
{
    public override bool Evaluate(StateMachine machine)
    {
        return true;
    }
}
