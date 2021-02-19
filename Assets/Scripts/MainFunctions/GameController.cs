using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    private Scene currentLevel;
    private UI ui;
    private string playerPrefabPath = "Prefabs/Player";
    // public 
    public UI UI
    {
        get
        {
            if (ui == null)
            {
                if (SceneManager.GetSceneByName(UILoader.UI_sceneName).isLoaded == true)
                {
                    var UIScene = SceneManager.GetSceneByName(UILoader.UI_sceneName);
                    var UIGameObject = UIScene.GetRootGameObjects()[0];
                    ui = UIGameObject.GetComponent<UI>();
                    Debug.Log("UI load completed");
                }
            }
            return ui;
        }
        private set { }
    }
    private UILoader UILoader { get; set; }
    public Scene CurrentLevel
    {
        get { return currentLevel; }
        set
        {
            currentLevel = value;

            reInitPlayer();

            TeamManager = new TeamManager();
            UnitManager = new UnitManager();

            LevelController = currentLevel.GetRootGameObjects()[0].GetComponent<LevelController>();

            foreach(UnitSpawnData data in LevelController.LevelInitData.UnitsToSpawn)
            {
                UnitSpawner.spawnUnit(data);
            }
        }
    }
    public LevelController LevelController { get; private set; }
    public Player Player { get; private set; }
    public TeamManager TeamManager { get; private set; } = new TeamManager();
    public UnitManager UnitManager { get; private set; } = new UnitManager();
    public UnitSpawner UnitSpawner { get; private set; }

    void Awake()
    {
        UILoader = gameObject.GetComponent<UILoader>();
        UnitSpawner = gameObject.AddComponent<UnitSpawner>();
        TeamManager = new TeamManager();
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void reInitPlayer()
    {
        if (Player != null)
        {
            GameObject.Destroy(Player.gameObject, 0);
        }
        var playerPrefab = Resources.Load(playerPrefabPath) as GameObject;
        var playerObject = Instantiate(playerPrefab);
        playerObject.transform.SetParent(this.gameObject.transform);
        Player = playerObject.GetComponent<Player>();
    }
}
