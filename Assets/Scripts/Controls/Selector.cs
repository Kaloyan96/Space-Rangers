using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class Selector : MonoBehaviour
{
    public Player Player { get; private set; }
    public SelectionManager SelectionManager { get { return Player.SelectionManager; } private set { } }
    public Selection CurrentSelection { get { return SelectionManager.CurrentSelection; } private set { } }
    public EventSystem CurrentEventSystem { get; set; }
    RaycastHit selectionHit;
    RaycastHit RMB_Hit;

    void Start()
    {
        CurrentEventSystem = EventSystem.current;
    }

    public void setPlayer(Player player)
    {
        if (Player == null)
        {
            Player = player;
        }
    }

    void Update()
    {

        if (CurrentEventSystem.IsPointerOverGameObject())
        {

        }
        else
        {
            if (Input.GetButtonDown("Fire1"))
            {
                leftMouseClick();
            }

            if (Input.GetButtonDown("Fire2"))
            {
                rightMouseClick();
            }


            if (isAlphaButtonDown())
            {
                if (Input.GetKey(KeyCode.LeftControl))
                {
                    saveSelection();
                }
                else if (Input.GetKey(KeyCode.LeftShift))
                {
                    addSelection();
                }
                else
                {
                    loadSelection();
                }
            }
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
                if (CurrentSelection.contains(selected))
                {
                    CurrentSelection.removeFromSelection(selected);
                }
                else
                {
                    CurrentSelection.addToSelection(selected);
                }
            }
            else
            {
                CurrentSelection.deselectAll();
                CurrentSelection.addToSelection(selected);
            }
        }
        else
        {
            CurrentSelection.deselectAll();
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
        if (CurrentSelection != null)
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
                    // CurrentSelection.pickUp(RMB_Hit.transform.gameObject.GetComponentInParent<Item>());
                }
                else if (layerMaskContainsLayer(actorsMask, hitLayer))
                {
                    Debug.Log("Following not implemented.");
                }
                else if (layerMaskContainsLayer(groundMask, hitLayer))
                {
                    CurrentSelection.moveToTarget(RMB_Hit.point, Input.GetButton("QueueCommands"));
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

    private bool isAlphaButtonDown()
    {
        bool res = false;
        for (KeyCode i = KeyCode.Alpha0; i <= KeyCode.Alpha9; i++)
        {
            if (Input.GetKeyDown(i))
            {
                // Debug.Log(i);
                res = true;
                break;
            }
        }
        return res;
    }

    public void saveSelection()
    {
        Debug.Log("Selector issue save selection.");
        SelectionManager.saveCurrentSelection(GetAlphaButtonDown().ToString());
        Debug.Log(CurrentSelection.Selected.Count);
    }

    private KeyCode GetAlphaButtonDown()
    {
        KeyCode res = KeyCode.None;
        for (KeyCode i = KeyCode.Alpha0; i <= KeyCode.Alpha9; i++)
        {
            if (Input.GetKeyDown(i))
            {
                res = i;
                // Debug.Log(i);
                break;
            }
        }
        return res;
    }

    public void addSelection()
    {
        Debug.Log("Selector issue add to selection.");
        SelectionManager.addToSelection(GetAlphaButtonDown().ToString());
        Debug.Log(CurrentSelection.Selected.Count);
    }

    public void loadSelection()
    {
        Debug.Log("Selector issue load selection.");
        CurrentSelection.deselectAll();
        SelectionManager.loadSelection(GetAlphaButtonDown().ToString());
        CurrentSelection.activate();
        Debug.Log(CurrentSelection.Selected.Count);
    }

    private void setSelected()
    {

    }
}
