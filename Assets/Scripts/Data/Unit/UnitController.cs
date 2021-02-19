using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public Unit Unit { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Unit = gameObject.GetComponent<Unit>();
    }

    public void moveTo(Vector3 destination, bool interupt)
    {
        if (interupt)
        {
            Unit.StateMachine.interupt();
        }
        Unit.StateMachine.addCommand(new MoveCommand(ScriptableObject.CreateInstance<DestinationReached>(), destination));
    }
}
