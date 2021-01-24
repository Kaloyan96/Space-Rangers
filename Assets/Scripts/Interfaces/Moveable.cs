using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface Moveable
{
    public abstract void moveTo(Vector3 position);
    public abstract void followTarget(Interactable target);
    public abstract void stop();
}
