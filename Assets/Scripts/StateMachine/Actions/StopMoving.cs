using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopMoving : StateMachineAction
{
    public override void Act(StateMachine machine)
    {
        if (machine is UnitStateMachine)
        {
            stopMotor((UnitStateMachine)machine);
        }
    }

    private void stopMotor(UnitStateMachine machine)
    {
        machine.Unit.Motor.stop();
    }
}
