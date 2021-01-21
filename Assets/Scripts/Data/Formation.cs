using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : ScriptableObject
{
    Vector3 center;
    Dictionary<ActorController, Vector3> relativePositions;
    // Start is called before the first frame update
    public Formation()
    {
        relativePositions = new Dictionary<ActorController, Vector3>();
    }

    public void addController(ActorController controller)
    {
        if (!contains(controller))
        {
            Vector3 pos = controller.transform.position;
            if (relativePositions.Count == 0)
            {
                center = pos;
            }
            /*else
            {
                center = center + (pos - center) / (relativePositions.Count + 1);
            }*/
            relativePositions.Add(controller, normalDeviation(controller));
            Debug.Log("Formation center: " + center);
        }
    }

    private Vector3 normalDeviation(ActorController controller){
        return - (center - controller.transform.position);
    }

    public void removeController(ActorController controller)
    {
        if (contains(controller))
        {
            Vector3 pos = controller.transform.position;
            if (relativePositions.Count == 0)
            {
                center = pos;
            }
            /*else
            {
                center = center + (center - pos) / (relativePositions.Count - 1);
            }*/
            relativePositions.Remove(controller);
            Debug.Log("Formation center: " + center);
        }
    }


    public void move(Vector3 target)
    {
        foreach (ActorController controller in relativePositions.Keys)
        {
            controller.moveTo(target + relativePositions[controller]);
        }
        center = target;
        Debug.Log("Center after movement is " + center);
    }

    public Vector3 deviation(ActorController controller)
    {
        return center - relativePositions[controller];
    }

    public Vector3 positionInFormation(ActorController controller)
    {
        return relativePositions[controller];
    }

    public bool contains(ActorController controller)
    {
        return relativePositions.ContainsKey(controller);
    }
}
