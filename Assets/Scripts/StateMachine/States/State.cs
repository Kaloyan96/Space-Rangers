using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// [CreateAssetMenu(menuName = "PluggableAI/State")]
[System.Serializable]
public class State : ScriptableObject
{
    public string Name { get; set; }
    public List<StateMachineAction> EntryActions { get; private set; }
    public List<StateMachineAction> Actions { get; private set; }
    public List<StateMachineAction> ExitActions { get; private set; }
    public List<Transition> Transitions { get; private set; }

    public State(string stateName)
    {
        Name = stateName;
        EntryActions = new List<StateMachineAction>();
        Actions = new List<StateMachineAction>();
        ExitActions = new List<StateMachineAction>();
        Transitions = new List<Transition>();
    }

    public void init(string name)
    {
        Name = name;
        EntryActions = new List<StateMachineAction>();
        Actions = new List<StateMachineAction>();
        ExitActions = new List<StateMachineAction>();
        Transitions = new List<Transition>();
    }

    public void init(string name, List<StateMachineAction> entryActions, List<StateMachineAction> actions, List<StateMachineAction> exitActions, List<Transition> transitions)
    {
        Name = name;
        EntryActions = entryActions;
        Actions = actions;
        ExitActions = exitActions;
        Transitions = transitions;
    }

    public void OnStateEntry(StateMachine machine)
    {
        // if (Name == StateFactory.interupt_name)
        // {
        //     Debug.Log("Enter into state: " + Name);
        // }

        // Debug.Log("Enter into state: " + Name);
        foreach (StateMachineAction action in EntryActions)
        {
            if (machine.CurrentState != this)
            {
                break;
            }
            action.Act(machine);
        }
    }

    public void UpdateState(StateMachine machine)
    {
        CheckAnyTransitions(machine);
        CheckTransitions(machine);
        DoActions(machine);
    }

    private void DoActions(StateMachine machine)
    {
        foreach (StateMachineAction action in Actions)
        {
            if (machine.CurrentState != this)
            {
                break;
            }
            action.Act(machine);
        }
    }

    private void CheckAnyTransitions(StateMachine machine)
    {
        foreach (Transition transition in machine.AnyTransitions)
        {
            if (machine.CurrentState != this)
            {
                break;
            }
            if (transition.Predicate.Evaluate(machine))
            {

                // if (Name == StateFactory.interupt_name)
                // {
                //     Debug.Log("Exit from state: " + Name);
                // }
                // Debug.Log("Predicate: " + transition.Predicate + " is true.");
                machine.TransitionToState(machine.Controller.getState(transition.TrueState));
            }
            else
            {
                machine.TransitionToState(machine.Controller.getState(transition.FalseState));
            }
        }
    }

    private void CheckTransitions(StateMachine machine)
    {
        foreach (Transition transition in Transitions)
        {
            if (machine.CurrentState != this)
            {
                break;
            }
            if (transition.Predicate.Evaluate(machine))
            {
                // Debug.Log("Predicate: " + transition.Predicate + " is true.");
                machine.TransitionToState(machine.Controller.getState(transition.TrueState));
            }
            else
            {
                machine.TransitionToState(machine.Controller.getState(transition.FalseState));
            }
        }
    }

    public void OnStateExit(StateMachine machine)
    {

        // Debug.Log("Exit state: " + Name);
        // if (Name == StateFactory.interupt_name)
        // {
        //     Debug.Log("Exit from state: " + Name);
        // }
        foreach (StateMachineAction action in ExitActions)
        {
            // Debug.Log("Exit action: " + action);
            if (machine.CurrentState != this)
            {
                break;
            }
            action.Act(machine);
        }
    }
}
