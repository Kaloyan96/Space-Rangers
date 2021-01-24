using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : Interaction
{
    public override void execute(params Interactable[] interactables)
    {
            Debug.Log(interactables[0]);
        if (areParametersValid(interactables))
        {
            
            Inventory inventory = (Inventory)interactables[0];
            Item item = (Item)interactables[1];
            if (inventory.canAddItem(item))
            {
                inventory.addItem(item);
                item.destroyWorldObject();
            }
        }
        else
        {
            //throw new InvalidIntercationParametersException();
        }
    }

    public override bool areParametersValid(Interactable[] interactables)
    {
        bool res = false;

        int length = interactables.Length;
            Debug.Log(length);
        if (length != 2)
        {
            Debug.Log("Incorect parameter length. " + length);
        }
        else if (!(interactables[0] is Inventory))
        {
            Debug.Log("Arg 0 is not Inventory ");
            Debug.Log(interactables[0]);
        }
        else if (!(interactables[1] is Item))
        {
            Debug.Log("Arg 1 is not Item " + interactables[1]);
        }
        else
        {
            Debug.Log("Pick up parameters are valid.");
            res = true;
        }

        return res;
    }
}
