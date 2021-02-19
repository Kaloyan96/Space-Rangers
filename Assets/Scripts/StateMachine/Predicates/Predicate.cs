using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Predicate : ScriptableObject
{
    public abstract bool Evaluate(StateMachine machine);
}