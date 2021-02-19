using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static string levelsPath = "Assets/Scenes/Levels/";
    public Dropdown levelsDropdown { get; private set; }
    public Button loadButton { get; private set; }
    private Dictionary<string, string> nameToPath = new Dictionary<string, string>();
    // public Scene currentScene { get; private set; }

    private GameController gameController;
    public GameController GameController { get { return gameController; } set { if (gameController == null) { gameController = value; } } }
    // Start is called before the first frame update
    void Start()
    {
        levelsDropdown = getDropdown();
        loadButton = getLoadButton();

        loadButton.onClick.AddListener(OnLoadButtonClick);

        populateNameToPaths();

        var options = new List<string>(nameToPath.Keys);
        options.Sort();
        levelsDropdown.AddOptions(options);
    }

    void Destroy()
    {
        loadButton.onClick.RemoveListener(OnLoadButtonClick);
    }

    private Dropdown getDropdown()
    {
        Dropdown res = null;
        var dropdown_GO = gameObject.transform.Find("Levels Dropdwown");
        res = dropdown_GO.gameObject.GetComponent<Dropdown>();
        return res;
    }

    private Button getLoadButton()
    {
        Button res = null;
        var button_GO = gameObject.transform.Find("Load Button");
        res = button_GO.gameObject.GetComponent<Button>();
        return res;
    }

    private void populateNameToPaths()
    {
        List<string> res = new List<string>();
        int count = SceneManager.sceneCountInBuildSettings;
        for (int i = 0; i < count; i++)
        {
            var currentPath = SceneUtility.GetScenePathByBuildIndex(i);
            if (currentPath.Contains(levelsPath))
            {
                nameToPath[Path.GetFileNameWithoutExtension(currentPath)] = currentPath;
                res.Add(currentPath);
            }
        }
    }

    private void OnLoadButtonClick()
    {
        var levelName = levelsDropdown.options[levelsDropdown.value].text;
        var levelPath = nameToPath[levelName];
        if (GameController.CurrentLevel.isLoaded == true)
        {
            var unloadOperation = SceneManager.UnloadSceneAsync(GameController.CurrentLevel);
            unloadOperation.completed += onLevelUnLoad;
        }
        else
        {
            loadLevel();
        }
    }

    private void onLevelUnLoad(AsyncOperation obj)
    {
        loadLevel();
    }

    private void loadLevel()
    {
        var levelName = levelsDropdown.options[levelsDropdown.value].text;
        var levelPath = nameToPath[levelName];
        var loadOperation = SceneManager.LoadSceneAsync(levelPath, LoadSceneMode.Additive);
        loadOperation.completed += onLevelLoad;
    }

    private void onLevelLoad(AsyncOperation obj)
    {
        var levelName = levelsDropdown.options[levelsDropdown.value].text;
        var levelPath = nameToPath[levelName];
        GameController.CurrentLevel = SceneManager.GetSceneByPath(levelPath);
    }
}
