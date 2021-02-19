using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public Transform LevelTransform { get { return transform; } set { } }

    [SerializeField]
    private LevelInitData levelInitData;
    public LevelInitData LevelInitData { get { return levelInitData; } set { levelInitData = value; } }
    void Awake()
    {
        // LevelInitData = gameObject.GetComponent<LevelInitData>();
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
