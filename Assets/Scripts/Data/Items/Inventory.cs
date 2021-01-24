using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour, Interactable
{
    Unit unit;
    List<Item> items;
    // Start is called before the first frame update
    void Start()
    {
        unit = gameObject.GetComponent<Unit>();
        items = new List<Item>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public Transform InteractionSource { get { return unit.InteractionSource; } set { } }
    public float InteractionRange { get { return unit.InteractionRange; } set { } }

    public void addItem(Item item){
        items.Add(item);
    }

    public bool canAddItem(Item item){
        return true;
    }

    public bool canRemoveItem(Item item){
        return items.Contains(item);
    }
}
