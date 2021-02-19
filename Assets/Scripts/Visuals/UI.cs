using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI : MonoBehaviour
{
    public GameController Game{get;private set;}
    void Start()
    {
        Game = gameObject.GetComponentInParent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
