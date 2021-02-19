using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachineInitialiser
{
    public const string trigger_interupt_name = "Interupt";
    public static UnitStateMachine makeUnitOne(Unit unit)
    {
        UnitStateMachine res = new UnitStateMachine();

        State idle = StateFactory.createState_Idle();
        State moving = StateFactory.createState_Moving();
        State interupting = StateFactory.createState_Interupting();

        res.Controller.addState(idle);
        res.Controller.addState(moving);
        res.Controller.addState(interupting);

        res.InitialState = idle;


        res.Controller.addTrigger(trigger_interupt_name, false);
        
        res.Controller.addNewAnyTransition(ScriptableObject.CreateInstance<ShouldInterupt>(), StateFactory.interupt_name, null);
        

        // res.Controller.addEntryActionToState("Moving", ScriptableObject.CreateInstance<MoveToDestinationAction>());

        // res.Controller.addExitActionToState("Interupting", ScriptableObject.CreateInstance<StopMoving>());
        // res.Controller.addExitActionToState("Interupting", ScriptableObject.CreateInstance<FinishInterupt>());

        // res.Controller.addNewTransitionToState("Idle", ScriptableObject.CreateInstance<ShouldMove>(), "Moving", null);
        // res.Controller.addNewTransitionToState("Moving", ScriptableObject.CreateInstance<DestinationReached>(), "Idle", null);
        // res.Controller.addNewTransitionToState("Interupting", ScriptableObject.CreateInstance<AlwaysTrue>(), "Idle", null);

        return res;
    }

    public static void initUnitOne(UnitStateMachine machine)
    {
        machine.init();

        State idle = StateFactory.createState_Idle();
        State moving = StateFactory.createState_Moving();
        State interupting = StateFactory.createState_Interupting();

        machine.Controller.addState(idle);
        machine.Controller.addState(moving);
        machine.Controller.addState(interupting);

        machine.InitialState = idle;


        machine.Controller.addTrigger(trigger_interupt_name, false);
        
        machine.Controller.addNewAnyTransition(ScriptableObject.CreateInstance<ShouldInterupt>(), StateFactory.interupt_name, null);
        

        // res.Controller.addEntryActionToState("Moving", ScriptableObject.CreateInstance<MoveToDestinationAction>());

        // res.Controller.addExitActionToState("Interupting", ScriptableObject.CreateInstance<StopMoving>());
        // res.Controller.addExitActionToState("Interupting", ScriptableObject.CreateInstance<FinishInterupt>());

        // res.Controller.addNewTransitionToState("Idle", ScriptableObject.CreateInstance<ShouldMove>(), "Moving", null);
        // res.Controller.addNewTransitionToState("Moving", ScriptableObject.CreateInstance<DestinationReached>(), "Idle", null);
        // res.Controller.addNewTransitionToState("Interupting", ScriptableObject.CreateInstance<AlwaysTrue>(), "Idle", null);

        
    }
}
