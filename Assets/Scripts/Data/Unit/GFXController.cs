using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GFXController : MonoBehaviour
{
    public Unit Unit { get; private set; }
    public OverheadText OverheadText { get; private set; }

    void Start()
    {
        Unit = gameObject.GetComponent<Unit>();

        OverheadText = gameObject.GetComponentInChildren<OverheadText>();
        OverheadText.disable();
    }

    void Update()
    {

    }

    public void OnSelect(){
        OverheadText.enable();
    }

    
    public void OnDeselect(){
        OverheadText.disable();
    }


}
