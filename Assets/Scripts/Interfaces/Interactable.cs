using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Interactable
{
    //public abstract void interact(Interaction interaction);
    public Transform InteractionSource{
        get;
        set;
    }
    public float InteractionRange{
        get;
        set;
    }

    //public void 
}
