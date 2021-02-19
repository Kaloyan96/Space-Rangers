using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitButton : MonoBehaviour
{
    public RectTransform RectTransform {get;  set;}
    public Canvas Canvas { get; private set; }
    void Start()
    {
        Canvas = gameObject.GetComponentInParent<Canvas>();
        RectTransform = gameObject.GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
