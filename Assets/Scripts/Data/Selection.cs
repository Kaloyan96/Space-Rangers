using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selection : ScriptableObject
{
    // Formation formation;
    public List<Selectable> Selected { get; private set; }
    // bool active = true;

    public Selection()
    {
        Selected = new List<Selectable>();
    }

    void OnEnable()
    {
        // formation = ScriptableObject.CreateInstance<Formation>();
    }

    public Selection copy()
    {
        Selection res = Instantiate(this);

        foreach (Selectable sel in Selected)
        {
            res.Selected.Add(sel);
        }
        // res.formation = this.formation;

        return res;
    }

    public bool contains(Selectable controller)
    {
        return Selected.Contains(controller);
    }

    public void addToSelection(Selectable selected)
    {
        if (!contains(selected))
        {
            this.Selected.Add(selected);
            selected.select();
            //formation.addUnit((Unit)selected);
            //Debug.Log(getCenter());
        }
    }

    public void removeFromSelection(Selectable selected)
    {
        if (contains(selected))
        {
            this.Selected.Remove(selected);
            selected.deselect();
            //formation.removeUnit((Unit)selected);
        }
    }

    public void deselectAll()
    {
        unmarkAll();
        Selected.Clear();
    }

    public void activate()
    {
        foreach (Selectable controller in Selected)
        {
            controller.select();
        }
    }

    private void unmarkAll()
    {
        foreach (Selectable controller in Selected)
        {
            controller.deselect();
        }
    }

    public void moveToTarget(Vector3 target, bool queueActive)
    {
        foreach (Selectable current in Selected)
        {
            if (current is Unit)
            {
                ((Unit)current).Controller.moveTo(target, !queueActive);
            }
            // if (current is Unit)
            // {
            //     Unit selectedUnit = (Unit)current;
            //     Command mvcmd = new Command();
            //     mvcmd.init(selectedUnit, target);
            //     selectedUnit.controller.addCommand(mvcmd);
            // }
        }
    }

    // public void pickUp(Item target)
    // {
    //     //VERY HOT CODE
    //     foreach (Selectable current in Selected)
    //     {
    //         if (current is Unit)
    //         {
    //             Unit unit = (Unit)current;
    //             Debug.Log("Unit " + unit + " will pick up item " + target);
    //             unit.pickUpItem(target);
    //             break;
    //         }
    //     }
    // }
}
