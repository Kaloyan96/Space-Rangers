using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldInterupt : Predicate
{

    public override bool Evaluate(StateMachine machine)
    {
        return machine.Triggers.ContainsKey(StateMachineInitialiser.trigger_interupt_name)
            && machine.Triggers[StateMachineInitialiser.trigger_interupt_name] == true;
    }
}
