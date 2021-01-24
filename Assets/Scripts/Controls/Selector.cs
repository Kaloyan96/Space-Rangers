using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Selector : MonoBehaviour
{
    Selection currentSelection;
    RaycastHit selectionHit;
    RaycastHit RMB_Hit;

    void Start()
    {
        //currentSelection = new Selection();
        currentSelection = ScriptableObject.CreateInstance<Selection>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            leftMouseClick();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            rightMouseClick();
        }
    }

    public void leftMouseClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out selectionHit))
        {
            select();
        }
        else
        {
            Debug.Log("Nothing has been raycasthit.");
        }
    }

    public void select()
    {
        Selectable selected = getHitSelectable();
        if (selected != null)
        {
            Debug.Log(selected.SelectableTransform.gameObject.name);
            if (Input.GetButton("QueueCommands"))
            {
                if (currentSelection.contains(selected))
                {
                    currentSelection.removeFromSelection(selected);
                }
                else
                {
                    currentSelection.addToSelection(selected);
                }
            }
            else
            {
                currentSelection.deselectAll();
                currentSelection.addToSelection(selected);
            }
        }
    }

    private Selectable getHitSelectable()
    {
        Selectable selected = null;
        try
        {
            //selectedController = selectionHit.collider.gameObject.transform.parent.gameObject.GetComponent<Selectable>();
            selected = selectionHit.collider.gameObject.GetComponentInParent<Selectable>();
        }
        catch (UnityException e)
        {
            Debug.Log(e.Message);
        }
        return selected;
    }

    public void rightMouseClick()
    {
        if (currentSelection != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RMB_Hit))
            {
                int hitLayer = RMB_Hit.transform.gameObject.layer;
                LayerMask groundMask = LayerMask.GetMask("Ground");
                LayerMask actorsMask = LayerMask.GetMask("Actors");
                if (RMB_Hit.transform.gameObject.GetComponentInParent<Item>() != null)
                {
                    Debug.Log("Pick up.");
                    currentSelection.pickUp(RMB_Hit.transform.gameObject.GetComponentInParent<Item>());
                }
                else if (layerMaskContainsLayer(actorsMask, hitLayer))
                {
                    Debug.Log("Following not implemented.");
                }
                else if (layerMaskContainsLayer(groundMask, hitLayer))
                {
                    if (Input.GetButton("QueueCommands"))
                    {
                        Vector3 tmp = RMB_Hit.point;
                        currentSelection.queueMoveToTarget(tmp);
                    }
                    else
                    {
                        currentSelection.moveToTarget(RMB_Hit.point);
                        Debug.Log("Moving.");
                    }
                }
                else
                {
                    Debug.Log("Not RMB interactable.");
                }
            }
            else
            {
                Debug.Log("Nothing ordered");
            }
        }
        else
        {
            Debug.Log("Nothing is selected.");
        }
    }

    private bool layerMaskContainsLayer(LayerMask layerMask, int layer)
    {
        return (layerMask == (layerMask | (1 << layer)));
    }

    private void setSelected()
    {

    }
}
