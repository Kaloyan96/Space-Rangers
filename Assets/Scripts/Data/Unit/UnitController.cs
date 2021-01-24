using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    private Command currentCommand;
    private bool idle;
    List<Command> commandQueue;
    Unit unit;
    
    // Start is called before the first frame update
    void Start()
    {
        unit = gameObject.GetComponent<Unit>();
        commandQueue = new List<Command>();
        currentCommand = null;
        idle = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!idle && (currentCommand != null && currentCommand.finished()))
        {
            Debug.Log(currentCommand);
            idle = true;
        }
        if (idle == true && commandQueue.Count != 0)
        {
            //Debug.Log(idle + " " + commandQueue.Count);
            idle = false;
            currentCommand = commandQueue[0];
            commandQueue.RemoveAt(0);

            currentCommand.execute();
            //Debug.Log("Executing" + currentCommand.finished());
        }
    }

    public void addCommand(Command cmd)
    {
        commandQueue.Add(cmd);
        Debug.Log(idle + " " + commandQueue.Count);
    }

    public void interupt()
    {
        Debug.Log("Interupt");
        commandQueue.Clear();
        idle = true;
    }
}
