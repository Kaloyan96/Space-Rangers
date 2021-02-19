using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestinationReached : Predicate
{
    public override bool Evaluate(StateMachine machine)
    {
        bool res = false;
        if (machine is UnitStateMachine)
        {
            res = isOnPosition((UnitStateMachine)machine);
        }
        return res;
    }

    private bool isOnPosition(UnitStateMachine machine)
    {
        bool res = false;
        Unit unit = machine.Unit;
        if (machine.CurrentCommand is MoveCommand)
        {
            MoveCommand mvcmd = ((MoveCommand)machine.CurrentCommand);
            Vector3 target = (Vector3)machine.CurrentCommand.Parameters["Destination"];
            // Debug.Log("Distance " + Vector3.Distance(unit.InteractionSource.position, target));
            // Debug.Log("Range " + unit.InteractionRange);
            // Debug.Log(Vector3.Distance(unit.InteractionSource.position, target) < unit.InteractionRange);
            res = Vector3.Distance(unit.InteractionSource.position, target) < unit.InteractionRange;
            
            // Debug.Log(res);
        }
        else
        {
            // res = true;
        }
        return res;
    }
}
