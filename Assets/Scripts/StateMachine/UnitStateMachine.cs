using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStateMachine : StateMachine
{
    public Unit Unit { get; private set; }
    public List<Command> CommandQueue { get; private set; }
    public Command CurrentCommand { get { return CommandQueue.Count > 0 ? CommandQueue[0] : null; } }

    public UnitStateMachine() : base()
    {
        init();
    }

    void Awake()
    {
        Unit = gameObject.GetComponent<Unit>();
        StateMachineInitialiser.initUnitOne(this);
    }

    public override void Tick()
    {
        base.Tick();
        // Debug.Log(CurrentState?.Name);
        if (CurrentCommand != null && CurrentCommand.finished(this))
        {
            // Debug.Log("Enter into state: " + Name);
            // Debug.Log("Command " + CurrentCommand + " finished.");
            CommandQueue.RemoveAt(0);
            // Debug.Log("Next command is " + CurrentCommand);
        }

        // Debug.Log("Unit Location is " + Unit.transform.position);
        // Debug.Log("Command destination is " + ((MoveCommand)CurrentCommand)?.Destination);
        // Debug.Log("Motor destination is " + Unit.Motor.NavAgent.destination);
    }

    public void init()
    {
        //Unit = unit;
        CommandQueue = new List<Command>();
    }

    public void addCommand(Command command)
    {
        // Debug.Log("Added command " + command);
        CommandQueue.Add(command);
    }

    public void interupt()
    {
        // Debug.Log("Trigger interupt");
        Triggers[StateMachineInitialiser.trigger_interupt_name] = true;
        CommandQueue.Clear();
    }
}
