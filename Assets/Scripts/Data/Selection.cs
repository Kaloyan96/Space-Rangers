using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : ScriptableObject
{
    Formation formation;
    List<Selectable> selectedControllers;

    public Selection()
    {
        selectedControllers = new List<Selectable>();
    }

    void OnEnable(){
        formation = ScriptableObject.CreateInstance<Formation>();
    }

    public bool contains(Selectable controller)
    {
        return selectedControllers.Contains(controller);
    }

    public void addController(Selectable controller)
    {
        if (!contains(controller))
        {
            selectedControllers.Add(controller);
            controller.select();
            formation.addController((ActorController)controller);
            //Debug.Log(getCenter());
        }
    }

    public void removeController(Selectable controller)
    {
        if (contains(controller))
        {
            selectedControllers.Remove(controller);
            controller.deselect();
            formation.removeController((ActorController)controller);
            //Debug.Log(getCenter());
        }
    }

    public void deselectAll()
    {
        foreach (Selectable controller in selectedControllers)
        {
            controller.deselect();
        }
        selectedControllers.Clear();
        formation = ScriptableObject.CreateInstance<Formation>();
    }

    public void setTarget(Vector3 target)
    {
        /*foreach (Selectable controller in selectedControllers)
        {
            controller.setTarget(target);
        }*/
        formation.move(target);
    }
}
