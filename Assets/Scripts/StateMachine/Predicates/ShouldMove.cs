using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShouldMove : Predicate
{
    public override bool Evaluate(StateMachine machine)
    {
        return isMoveCommand(machine);
    }

    private bool isMoveCommand(StateMachine machine)
    {
        bool res = false;
        if (machine is UnitStateMachine)
        {
            res = ((UnitStateMachine)machine).CurrentCommand is MoveCommand;
        }
        return res;
    }
}
