using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitManager
{
    public Dictionary<ID, Unit> Units { get; private set; } = new Dictionary<ID, Unit>();
    public IDAuthority IDAuthority { get; private set; } = new IDAuthority("Unit");

    public Unit getUnit(ID id)
    {
        Unit res = null;
        if (Units.ContainsKey(id))
        {
            res = Units[id];
        }
        return res;
    }

    public void registerUnit(Unit unit)
    {
        if (unit.ID == null)
        {
            ID id = IDAuthority.getFreeID();
            unit.ID = id;
            Units[id] = unit;
        }
    }
}
