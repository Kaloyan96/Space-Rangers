using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Transition
{
    public Predicate Predicate { get; set; }
    public string TrueState { get; set; }
    public string FalseState { get; set; }

    public Transition(Predicate predicate, string trueState, string falseState)
    {
        Predicate = predicate;
        TrueState = trueState;
        FalseState = falseState;
    }
}