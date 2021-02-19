using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameController Game{get;private set;}
    public Selector Selector { get; private set; }
    public SelectionManager SelectionManager { get; private set; }

    // Start is called before the first frame update
    void Start()
    {
        Game = gameObject.GetComponentInParent<GameController>();
        SelectionManager = GetComponentInChildren<SelectionManager>();
        Selector = GetComponentInChildren<Selector>();
        Selector.setPlayer(this);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
