using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameController))]
public class UnitSpawner : MonoBehaviour
{
    // public List<UnitSpawnData> ToSpawn { get; private set;} = new List<UnitSpawnData>();
    public GameController GameController { get; private set; }

    void Awake()
    {
        GameController = gameObject.GetComponent<GameController>();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void spawnUnit(UnitSpawnData spawnData)
    {
        Unit unit = instantiateUnit(spawnData);
        if (unit != null)
        {
            GameController.UnitManager.registerUnit(unit);

            if (spawnData.parent != null)
            {
                unit.transform.SetParent(spawnData.parent);
            }
            else
            {
                unit.transform.SetParent(GameController.LevelController.LevelTransform);
            } 

            unit.transform.position = spawnData.spawnPoint + unit.transform.parent.position;

            if (spawnData.teamName != null)
            {

                unit.Team = GameController.TeamManager.getTeam(spawnData.teamName);
            }
            else
            {
                unit.Team = GameController.TeamManager.getTeam("Default");
            }
        }
    }

    private static Unit instantiateUnit(UnitSpawnData spawnData)
    {
        var unitPrefab = Resources.Load(spawnData.prefabPath) as GameObject;
        var unitObject = GameObject.Instantiate(unitPrefab);
        return unitObject.GetComponent<Unit>();
    }
}
