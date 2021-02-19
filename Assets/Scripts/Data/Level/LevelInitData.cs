using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Levels/InitData")]
[System.Serializable]
public class LevelInitData : ScriptableObject
{
    [SerializeField]
    private List<UnitSpawnData> unitsToSpawn;
    public List<UnitSpawnData> UnitsToSpawn { get { return unitsToSpawn; } private set { unitsToSpawn = value; } }// = new List<UnitSpawnData>();
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
