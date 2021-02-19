using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

// [CreateAssetMenu(menuName = "Units/Unit")]
[System.Serializable]
public class Unit : MonoBehaviour, Selectable, Interactable, Moveable, Damageable
{
    [SerializeField]
    public Team Team { get; set; }
    public ID ID { get; set; }
    
    public CharacterStats Stats { get; private set; }
    public UnitMotor Motor { get; private set; }
    public Inventory Inventory { get; private set; }
    public UnitController Controller { get; private set; }
    public UnitStateMachine StateMachine { get; private set; }
    public GFXController GFXController { get; private set; }

    public Transform InteractionSource { get { return transform; } set { } }
    public float InteractionRange { get { return Motor.NavAgent.radius; } set { } }
    public Transform SelectableTransform { get { return transform; } set { } }


    // Start is called before the first frame update
    void Awake()
    {
        Stats = ScriptableObject.CreateInstance<CharacterStats>();
        Motor = gameObject.GetComponent<UnitMotor>();
        Inventory = gameObject.GetComponent<Inventory>();
        Controller = gameObject.GetComponent<UnitController>();
        StateMachine = gameObject.GetComponent<UnitStateMachine>();
        GFXController = gameObject.GetComponent<GFXController>();
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.Tick();
    }

    public void select()
    {
        GFXController.OnSelect();
    }

    public void deselect()
    {
        GFXController.OnDeselect();
    }

    public void moveTo(Vector3 position)
    {
        //unitStateMachine.set
        Motor.moveToPoint(position);
        //coroutine = WaitAndPrint(2.0f);
    }

    public void followTarget(Interactable target)
    {
        Motor.followTarget(target);
    }

    public void stop()
    {
        Motor.stop();
    }

    public void takeDamage(float damage)
    {
        Stats.TakeDamage(damage);
        if (Stats.CurrentHealth <= 0)
        {
            //Die
        }
    }

    // public void pickUpItem(Item item)
    // {
    //     float dist = Vector3.Distance(item.InteractionSource.position, gameObject.transform.position);
    //     Debug.Log("Item pos. " + item.InteractionSource.position);
    //     Debug.Log("Unit pos. " + InteractionSource.position);
    //     if (dist < item.InteractionRange)
    //     {
    //         Debug.Log("Within pick up range. " + dist);
    //         PickUp pickUp = ScriptableObject.CreateInstance<PickUp>();
    //         pickUp.execute(Inventory, item);
    //     }
    //     else
    //     {
    //         //Command cmd = ScriptableObject.CreateInstance<Command>();
    //         Debug.Log("Outside pick up range. " + dist);
    //         //cmd.execute();
    //     }
    // }
}
