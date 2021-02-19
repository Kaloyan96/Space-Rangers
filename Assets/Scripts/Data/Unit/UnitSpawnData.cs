using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Units/SpawnData")]
[System.Serializable]
public class UnitSpawnData : ScriptableObject
{
    public Vector3 spawnPoint;
    public Transform parent;
    public string prefabPath;
    public string teamName;
}
