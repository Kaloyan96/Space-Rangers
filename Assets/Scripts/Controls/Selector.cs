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
        ActorController hitController = getHitActorController();
        if (hitController != null)
        {
            if (Input.GetButton("QueueCommands"))
            {
                Debug.Log(hitController.name);
                if (currentSelection.contains(hitController))
                {
                    currentSelection.removeController(hitController);
                }
                else
                {
                    currentSelection.addController(hitController);
                }
            }
            else
            {
                currentSelection.deselectAll();
                currentSelection.addController(hitController);
            }
        }
    }

    private ActorController getHitActorController()
    {
        ActorController selectedController = null;
        try
        {
            //selectedController = selectionHit.collider.gameObject.transform.parent.gameObject.GetComponent<ActorController>();
            selectedController = selectionHit.collider.gameObject.GetComponentInParent<ActorController>();
        }
        catch (UnityException e)
        {
            Debug.Log(e.Message);
        }
        return selectedController;
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
                if(layerMaskContainsLayer(actorsMask, hitLayer)){
                    Debug.Log("Following.");
                }
                else if (layerMaskContainsLayer(groundMask, hitLayer))
                {
                    currentSelection.setTarget(RMB_Hit.point);
                    Debug.Log("Moving.");
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
