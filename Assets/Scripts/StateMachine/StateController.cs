using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateController
{
    public StateMachine Machine { get; private set; }

    public State CurrentState { get { return Machine.CurrentState; } set { Machine.CurrentState = value; } }

    public Dictionary<string, State> States { get { return Machine.States; } set { } }


    public StateController(StateMachine machine)
    {
        Machine = machine;
    }

    public bool hasState(string stateName)
    {
        if (stateName != null)
        {
            return Machine.States.ContainsKey(stateName);
        }
        else if (Machine.RemainState == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public State getState(string stateName)
    {
        if (stateName != null && hasState(stateName))
        {
            return States[stateName];
        }
        else
        {
            //Debug.LogWarning("State " + stateName + " does not exist within this controlled machine.");
            return null;
        }
    }

    public bool getTrigger(string name)
    {
        if (Machine.Triggers.ContainsKey(name))
        {
            return Machine.Triggers[name];
        }
        else
        {
            // Debug.LogWarning("Trigger " + name + " is not registered with this controlled machine.");
            return false;
        }
    }


    public void addState(string stateName)
    {
        if (!hasState(stateName))
        {
            State newState = ScriptableObject.CreateInstance<State>();
            newState.init(stateName);
            States[stateName] = newState;
        }
    }

    public void addState(State state)
    {
        if (!hasState(state.Name))
        {

            States[state.Name] = state;
        }
    }

    public void addTransitionToState(string stateName, Transition transition)
    {
        States[stateName].Transitions.Add(transition);
    }

    public void addTransitionToState(string stateName, Predicate predicate, string trueState, string falseState)
    {
        States[stateName].Transitions.Add(new Transition(predicate, trueState, falseState));
    }

    public void addNewTransitionToState(string stateName, Predicate predicate, string trueStateName, string falseStateName)
    {
        States[stateName].Transitions.Add(createTransition(predicate, trueStateName, falseStateName));
    }

    public void addNewAnyTransition(Predicate predicate, string trueStateName, string falseStateName)
    {
        Machine.AnyTransitions.Add(createTransition(predicate, trueStateName, falseStateName));
    }

    private Transition createTransition(Predicate predicate, string trueStateName, string falseStateName)
    {
        if (!hasState(trueStateName))
        {
            Debug.LogWarning("State machine does not have " + trueStateName + " state.");
        }
        if (!hasState(falseStateName))
        {
            Debug.LogWarning("State machine does not have " + falseStateName + " state.");
        }

        return new Transition(predicate, trueStateName, falseStateName);
    }

    public void addEntryActionToState(string stateName, StateMachineAction action)
    {
        States[stateName].EntryActions.Add(action);
    }

    public void addActionToState(string stateName, StateMachineAction action)
    {
        States[stateName].Actions.Add(action);
    }

    public void addExitActionToState(string stateName, StateMachineAction action)
    {
        States[stateName].ExitActions.Add(action);
    }

    public void addTrigger(string triggerName, bool initValue)
    {
        Machine.Triggers[triggerName] = initValue;
    }
}
