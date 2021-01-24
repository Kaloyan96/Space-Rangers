using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour, Interactable
{

    // Start is called before the first frame update
    void Start()
    {
        //destroyWorldObject();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform InteractionSource { get { return transform; } set { } }
    public float InteractionRange { get {return 3f;} set { } }
    public void interact(Interaction interaction)
    {
        throw new System.NotImplementedException();
    }

    public void destroyWorldObject()
    {
        Destroy(gameObject);
    }

    public void createWorldObject()
    {

    }

    void OnDrawGizmosSelected()
    {
        Transform gizmoTransform = InteractionSource;
        if (InteractionSource == null)
        {
            gizmoTransform = transform;
        }
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(gizmoTransform.position, InteractionRange);
    }
}
