using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Selectable
{
    public Transform SelectableTransform
    {
        get;
        set;
    }
    public abstract void select();
    public abstract void deselect();
}
