using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : ScriptableObject
{
    Vector3 center;
    Dictionary<Unit, Vector3> relativePositions;
    // Start is called before the first frame update
    public Formation()
    {
        relativePositions = new Dictionary<Unit, Vector3>();
    }

    public void addUnit(Unit unit)
    {
        if (!contains(unit))
        {
            Vector3 pos = unit.transform.position;
            if (relativePositions.Count == 0)
            {
                center = pos;
            }
            /*else
            {
                center = center + (pos - center) / (relativePositions.Count + 1);
            }*/
            relativePositions.Add(unit, deviationFromCenter(unit));
            Debug.Log("Formation center: " + center);
        }
    }

    private Vector3 deviationFromCenter(Unit unit)
    {
        return -(center - unit.transform.position);
    }

    public void removeUnit(Unit unit)
    {
        if (contains(unit))
        {
            Vector3 pos = unit.transform.position;
            if (relativePositions.Count == 0)
            {
                center = pos;
            }
            /*else
            {
                center = center + (center - pos) / (relativePositions.Count - 1);
            }*/
            relativePositions.Remove(unit);
            Debug.Log("Formation center: " + center);
        }
    }

    public Vector3 actualCenter()
    {
        Vector3 pos = new Vector3(0, 0, 0);
        foreach (Unit unit in relativePositions.Keys)
        {
            pos += unit.transform.position;
        }
        return pos / relativePositions.Count;
    }

    public Vector3 positionInFormation(Unit unit)
    {
        return relativePositions[unit];
    }

    public bool contains(Unit unit)
    {
        return relativePositions.ContainsKey(unit);
    }
}
