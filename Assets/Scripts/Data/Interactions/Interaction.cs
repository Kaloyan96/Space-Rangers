using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Interaction : ScriptableObject
{
    public abstract void execute(params Interactable[] interactables);
    public abstract bool areParametersValid(params Interactable[] interactables);
}
