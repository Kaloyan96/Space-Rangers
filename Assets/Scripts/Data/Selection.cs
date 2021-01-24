using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : ScriptableObject
{
    Formation formation;
    List<Selectable> selected;

    public Selection()
    {
        selected = new List<Selectable>();
    }

    void OnEnable()
    {
        formation = ScriptableObject.CreateInstance<Formation>();
    }

    public bool contains(Selectable controller)
    {
        return selected.Contains(controller);
    }

    public void addToSelection(Selectable selected)
    {
        if (!contains(selected))
        {
            this.selected.Add(selected);
            selected.select();
            //formation.addUnit((Unit)selected);
            //Debug.Log(getCenter());
        }
    }

    public void removeFromSelection(Selectable selected)
    {
        if (contains(selected))
        {
            this.selected.Remove(selected);
            selected.deselect();
            //formation.removeUnit((Unit)selected);
        }
    }

    public void deselectAll()
    {
        foreach (Selectable controller in selected)
        {
            controller.deselect();
        }
        selected.Clear();
        formation = ScriptableObject.CreateInstance<Formation>();
    }

    public void moveToTarget(Vector3 target)
    {
        foreach (Selectable current in selected)
        {
            // if(current is Moveable){
            //     Moveable selectedMoveable = (Moveable)current;
            //     selectedMoveable.moveTo(target);
            // }
            if (current is Unit)
            {
                Unit selectedUnit = (Unit)current;
                selectedUnit.interupt();
                selectedUnit.moveTo(target);
            }
        }
    }

    public void queueMoveToTarget(Vector3 target)
    {
        foreach (Selectable current in selected)
        {
            // if(current is Moveable){
            //     Moveable selectedMoveable = (Moveable)current;
            //     selectedMoveable.moveTo(target);
            // }
            if (current is Unit)
            {
                Unit selectedUnit = (Unit)current;
                Command mvcmd = new Command();
                mvcmd.init(selectedUnit, target);
                selectedUnit.controller.addCommand(mvcmd);
            }
        }
    }

    public void pickUp(Item target)
    {
        //VERY HOT CODE
        foreach (Selectable current in selected)
        {
            if (current is Unit)
            {
                Unit unit = (Unit)current;
                Debug.Log("Unit " + unit + " will pick up item " + target);
                unit.pickUpItem(target);
                break;
            }
        }
    }
}
