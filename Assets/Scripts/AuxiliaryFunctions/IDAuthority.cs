using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDAuthority
{
    private int currentHighestID;
    private string prefix;
    private List<int> releasedIds;
    public IDAuthority(string prefix)
    {
        this.prefix = prefix;
        currentHighestID = 0;
        releasedIds = new List<int>();
    }

    public ID getFreeID()
    {
        int id_num;
        if (releasedIds.Count > 0)
        {
            id_num = releasedIds[0];
            releasedIds.RemoveAt(0);
        }
        else
        {
            id_num = currentHighestID;
            currentHighestID++;
        }
        return new ID(this, prefix, id_num);
    }

    public void releaseID(ID id)
    {
        // TO DO
    }
}
