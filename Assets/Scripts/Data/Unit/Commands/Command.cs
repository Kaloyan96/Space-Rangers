using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command
{
    private Unit unit;
    private Vector3 target;
    public void init(Unit unit, Vector3 target)
    {
        this.unit = unit;
        this.target = target;
    }
    public void execute()
    {
        unit.moveTo(target);
    }

    public bool finished()
    {
        //Debug.Log(unit.InteractionSource.position + " " + target);
        return Vector3.Distance(unit.InteractionSource.position, target) < unit.InteractionRange;
    }
}
