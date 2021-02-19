using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Team : ScriptableObject
{
    public string Name;
    public List<Team> Enemies { get; private set; } = new List<Team>();
    public List<Team> Allies { get; private set; } = new List<Team>();

    public bool isEnemy(Team team){
        return Enemies.Contains(team);
    }
}
