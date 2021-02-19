using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public StateController Controller { get; private set; }
    public Dictionary<string, State> States { get; private set; }
    public List<Transition> AnyTransitions { get; private set; }
    public Dictionary<string, bool> Triggers { get; private set; }

    public State RemainState { get; set; }
    [HideInInspector] public float stateTimeElapsed;

    public State InitialState { get; set; }

    [SerializeField]
    private State currentState;
    public State CurrentState { get { return currentState; } set { currentState = value; } }

    private bool aiActive;

    public StateMachine()
    {
        init();
    }

    void Awake()
    {
        init();
    }

    private void init()
    {
        Controller = new StateController(this);
        States = new Dictionary<string, State>();
        AnyTransitions = new List<Transition>();
        Triggers = new Dictionary<string, bool>();
    }

    public virtual void Tick()
    {
        //if (!aiActive) return;
        if (CurrentState == null)
        {
            CurrentState = InitialState;
        }
        CurrentState.UpdateState(this);

    }

    public void TransitionToState(State nextState)
    {
        //if (nextState != remainState)
        if (nextState != RemainState)
        {
            // if (nextState.Name == StateFactory.interupt_name)
            // {
            //     Debug.Log("Enter into state: " + nextState.Name);
            // }
            // Debug.Log("Transition from " + CurrentState.Name + " to " + nextState.Name);
            CurrentState.OnStateExit(this);
            CurrentState = nextState;
            CurrentState.OnStateEntry(this);
            OnExitState();
        }
    }

    public bool CheckIfCountDownElapsed(float duration)
    {
        stateTimeElapsed += Time.deltaTime;
        return (stateTimeElapsed >= duration);
    }

    private void OnExitState()
    {
        stateTimeElapsed = 0;
    }
}
