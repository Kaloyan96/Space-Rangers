using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualController : MonoBehaviour
{
    private ActorData actorData;
    private GameObject selectionVisual;
    private GameObject targetVisual;

    void Start()
    {
        actorData = gameObject.GetComponent<ActorData>();
    }
    public void markAsSelected()
    {
        selectionVisual = Instantiate(actorData.selectionPrefab, actorData.transform());
        selectionVisual.transform.position = actorData.position();
        selectionVisual.transform.SetParent(actorData.transform());
    }

    public void unmarkAsSelected()
    {
        Destroy(selectionVisual);
    }

    public void visualizeTarget()
    {
        if (actorData.target != null)
        {
            targetVisual = Instantiate(actorData.targetPrefab, actorData.target, Quaternion.identity);
            targetVisual.transform.position = actorData.target;
        }
    }

    public void unvisualizeTarget()
    {
        if (targetVisual != null)
        {
            Destroy(targetVisual);
            targetVisual = null;
        }
    }
}
