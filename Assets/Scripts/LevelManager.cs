using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using System.IO;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    public List<LevelData> levelsData = new List<LevelData>();
    private int currentLevelIndex = 0;

    private void Awake()
    {
        // 单例模式
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    void Start()
    {
        // 加载关卡数据
        LoadLevelData();
    }

    void LoadLevelData()
    {
        string filePath = Path.Combine(Application.dataPath, "Level", "levels.json");
        string jsonContent;

        if (Application.platform == RuntimePlatform.Android)
        {
            // 在Android平台上使用UnityWebRequest来读取JSON文件
            UnityEngine.Networking.UnityWebRequest www = UnityEngine.Networking.UnityWebRequest.Get(filePath);
            www.SendWebRequest();
            while (!www.isDone) { }
            jsonContent = www.downloadHandler.text;
        }
        else
        {
            // 在其他平台上直接使用StreamReader来读取JSON文件
            jsonContent = System.IO.File.ReadAllText(filePath);
        }

        // 解析JSON数据
        LevelList levelList = JsonUtility.FromJson<LevelList>(jsonContent);
        levelsData = levelList.levels;
    }

    // 在事件触发时调用此方法来加载下一个关卡
    public void LoadNextLevel()
    {
        if (currentLevelIndex < levelsData.Count)
        {
            // Unload current scene if needed
            if (SceneManager.sceneCount > 1)
            {
                SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).name);
            }

            List<string> scenesToLoad = levelsData[currentLevelIndex].scenes;
            StartCoroutine(LoadScenesAsync(scenesToLoad));
            currentLevelIndex++;
        }
        else
        {
            Debug.Log("All levels are loaded.");
            // 如果已经加载完所有关卡，可以在这里执行其他操作，比如显示游戏结束画面等
        }
    }

    IEnumerator LoadScenesAsync(List<string> scenesToLoad)
    {
        // Unload current scene if needed
        if (SceneManager.sceneCount > 1)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).name);
        }

        foreach (string sceneName in scenesToLoad)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            while (!asyncLoad.isDone)
            {
                yield return null;
            }
        }
    }

[System.Serializable]
public class LevelData
{
    public int level;
    public List<string> scenes;
}

[System.Serializable]
public class LevelList
{
    public List<LevelData> levels;
}
    }