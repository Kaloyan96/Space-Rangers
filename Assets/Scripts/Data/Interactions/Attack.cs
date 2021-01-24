using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : ScriptableObject
{
    Unit attacker;
    Damageable attacked;

    public void execute()
    {
        attacked.takeDamage(attacker.Stats.calculateDamage());
    }
}
