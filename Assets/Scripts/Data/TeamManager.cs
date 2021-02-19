using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeamManager
{
    public Dictionary<string, Team> Teams { get; private set; } = new Dictionary<string, Team>();
    public Team getTeam(string name)
    {
        Team res = null;
        if (!Teams.ContainsKey(name))
        {
            Teams[name] = ScriptableObject.CreateInstance<Team>();
            Teams[name].Name = name;
        }
        res = Teams[name];
        return res;
    }
}
