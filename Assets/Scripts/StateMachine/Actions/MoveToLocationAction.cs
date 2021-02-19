using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToDestinationAction : StateMachineAction
{
    public override void Act(StateMachine machine)
    {
        if (machine is UnitStateMachine)
        {
            UnitStateMachine actedMachine = (UnitStateMachine)machine;
            if (actedMachine.CurrentCommand is IHasDestination)
            {
                execute(actedMachine);
            }
        }
    }

    private void execute(UnitStateMachine actedMachine)
    {
        UnitMotor(actedMachine).moveToPoint(Destination(actedMachine));
    }

    private UnitMotor UnitMotor(UnitStateMachine actedMachine)
    {
        return actedMachine.Unit.Motor;
    }
    private Vector3 Destination(UnitStateMachine actedMachine)
    {
        return ((IHasDestination)actedMachine.CurrentCommand).Destination;
    }
}
