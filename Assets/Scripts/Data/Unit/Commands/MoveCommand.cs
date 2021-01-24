using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    public void execute(Unit unit, Vector3 target)
    {
        
    }

    public bool finished(Unit unit, Vector3 target)
    {
        return Vector3.Distance(unit.InteractionSource.position, target) < unit.InteractionRange;
    }
}