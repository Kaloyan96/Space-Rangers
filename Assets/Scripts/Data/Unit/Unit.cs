using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, Selectable, Interactable, Moveable, Damageable
{
    UnitMotor unitMotor;
    CharacterStats stats;
    Inventory inventory;
    public CharacterStats Stats { get { return stats; } set { } }
    public Transform InteractionSource { get { return transform; } set { } }
    public float InteractionRange { get { return unitMotor.NavAgent.radius; } set { } }
    public Transform SelectableTransform { get { return transform; } set { } }
    public UnitController controller;

    // Start is called before the first frame update
    void Start()
    {
        stats = ScriptableObject.CreateInstance<CharacterStats>();
        unitMotor = gameObject.GetComponent<UnitMotor>();
        inventory = gameObject.GetComponent<Inventory>();
        controller = gameObject.GetComponent<UnitController>();;
        Debug.Log(inventory);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void select()
    {
        //throw new System.NotImplementedException();
    }

    public void deselect()
    {
        //throw new System.NotImplementedException();
    }

    public void addCommand(Command cmd){

    }

    public void beginCommandExectution(){

    }

    public void moveTo(Vector3 position)
    {
        //unitStateMachine.set
        unitMotor.moveToPoint(position);
        //coroutine = WaitAndPrint(2.0f);
    }

    public void followTarget(Interactable target)
    {
        unitMotor.followTarget(target);
    }

    public void stop()
    {
        unitMotor.stop();
    }

    public void takeDamage(float damage)
    {
        stats.TakeDamage(damage);
        if (stats.currentHealth <= 0)
        {
            //Die
        }
    }

    public void interupt(){
        controller.interupt();
    }

    public void pickUpItem(Item item)
    {
        float dist = Vector3.Distance(item.InteractionSource.position, gameObject.transform.position);
        Debug.Log("Item pos. " + item.InteractionSource.position);
        Debug.Log("Unit pos. " + InteractionSource.position);
        if (dist < item.InteractionRange)
        {
            Debug.Log("Within pick up range. " + dist);
            PickUp pickUp = ScriptableObject.CreateInstance<PickUp>();
            Debug.Log(inventory);
            pickUp.execute(inventory, item);
        }else{
            //Command cmd = ScriptableObject.CreateInstance<Command>();
            Debug.Log("Outside pick up range. " + dist);
            //cmd.execute();
        }
    }
}
