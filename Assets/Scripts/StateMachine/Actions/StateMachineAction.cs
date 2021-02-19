using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateMachineAction : ScriptableObject
{
        public abstract void Act(StateMachine machine);
}
