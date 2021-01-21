using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MovementController : MonoBehaviour
{
    private ActorData actorData;

    // Start is called before the first frame update
    void Start()
    {
        actorData = gameObject.GetComponent<ActorData>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void moveTo(Vector3 target)
    {
        removeTarget();        
        actorData.navMeshAgent.destination = actorData.target;
    }

    public void removeTarget()
    {
        actorData.visualController.unvisualizeTarget();
        //target = new Vector3();
    }
}
