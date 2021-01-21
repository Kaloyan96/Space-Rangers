using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ActorData : MonoBehaviour
{
    public GameObject selectionPrefab;
    public GameObject targetPrefab;
    public Vector3 target;
    public GameObject actor;
    public VisualController visualController;
    public MovementController movementController;
    public ActorController actorController;
    public NavMeshAgent navMeshAgent;
    // Start is called before the first frame update
    protected void Start()
    {
        actor = gameObject;
        visualController = gameObject.GetComponent<VisualController>();
        movementController = gameObject.GetComponent<MovementController>();
        actorController = gameObject.GetComponent<ActorController>();
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public new Transform transform()
    {
        return actor.transform;
    }

    public Vector3 position()
    {
        return actor.transform.position;
    }

    public int getLayer()
    {
        return actor.layer;
    }
}
