using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishInterupt : StateMachineAction
{
    public override void Act(StateMachine machine)
    {
        machine.Triggers[StateMachineInitialiser.trigger_interupt_name] = false;
    }
}
