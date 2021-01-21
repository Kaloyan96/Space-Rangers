using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorController : MonoBehaviour, Selectable
{
    private ActorData actorData;
    public ActorData ActorData { get; set; }

    // Start is called before the first frame update
    protected void Start()
    {
        actorData = gameObject.GetComponent<ActorData>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void select()
    {
        actorData.visualController.markAsSelected();
        actorData.visualController.visualizeTarget();
    }

    public void deselect()
    {
        actorData.visualController.unmarkAsSelected();
        actorData.visualController.unvisualizeTarget();
    }

    public void moveTo(Vector3 target)
    {
        actorData.target = target;
        actorData.movementController.moveTo(target);
        actorData.visualController.visualizeTarget();
    }

    public Vector3 position()
    {
        return actorData.position();
    }

    public int getLayer()
    {
        return actorData.actor.layer;
    }
}
