using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UILoader : MonoBehaviour
{
    public static string UI_sceneName = "UI";
    public static string Menu_sceneName = "Menu";
    public GameObject GameRoot { get { return gameObject; } private set { } }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
        {
            toggleUI();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            toggleMenu();
        }

    }

    private void toggleUI()
    {
        if (SceneManager.GetSceneByName(UI_sceneName).isLoaded == false)
        {
            // Debug.Log("Load UI");
            var loadOperation = SceneManager.LoadSceneAsync(UI_sceneName, LoadSceneMode.Additive);
            loadOperation.completed += OnUILoadCompleted;
        }
        else
        {
            // Debug.Log("Unload UI");
            SceneManager.UnloadSceneAsync(UI_sceneName);

        }
    }

    private void OnUILoadCompleted(AsyncOperation obj)
    {
        var commandSlateController = getCommandSlateController();
        var commandSlateButtonHandler = getcommandSlateButtonHandler();
        if (commandSlateButtonHandler != null && commandSlateController != null)
        {

        }
    }

    private CommandSlateController getCommandSlateController()
    {
        CommandSlateController res = null;
        var UIScene = SceneManager.GetSceneByName(UI_sceneName);
        var UIRoot = UIScene.GetRootGameObjects()[0];
        res = UIRoot.GetComponentInChildren<CommandSlateController>();
        return res;
    }

    private CommandSlateButtonHandler getcommandSlateButtonHandler()
    {
        CommandSlateButtonHandler res = null;
        res = gameObject.GetComponentInChildren<CommandSlateButtonHandler>();
        return res;
    }

    private void toggleMenu()
    {
        if (SceneManager.GetSceneByName(Menu_sceneName).isLoaded == false)
        {
            // Debug.Log("Open Menu");
            var loadOperation = SceneManager.LoadSceneAsync(Menu_sceneName, LoadSceneMode.Additive);
            loadOperation.completed += OnMenuLoadCompleted;
        }
        else
        {
            // Debug.Log("Close Menu");
            SceneManager.UnloadSceneAsync(Menu_sceneName);

        }
    }

    private void OnMenuLoadCompleted(AsyncOperation obj)
    {
        var MenuScene = SceneManager.GetSceneByName(Menu_sceneName);
        var MenuRoot = MenuScene.GetRootGameObjects()[0];
        MenuRoot.GetComponentInChildren<LevelLoader>().GameController = GameRoot.GetComponent<GameController>();
    }
}
