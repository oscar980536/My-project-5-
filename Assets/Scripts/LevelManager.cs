using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class LevelManager : MonoBehaviour
{
    private static LevelManager _instance;
    public static LevelManager Instance { get { return _instance; } }

    public List<LevelData> levelsData = new List<LevelData>();
    private int currentLevelIndex = 0;

    // Google Sheets 数据 URL
    public string googleSheetUrl = "https://script.google.com/macros/s/AKfycbz4kLOhY6PFzWmiDftDz2A2S93hPTSslDSPYbVS4Id-9xT9P9FoL3SLkbU1V1hiHvriCA/exec";

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
        LoadLevelDataFromGoogleSheet();
    }

    void LoadLevelDataFromGoogleSheet()
    {
        StartCoroutine(DownloadGoogleSheetData());
    }

    IEnumerator DownloadGoogleSheetData()
    {
        // 发送网络请求获取 Google Sheets 数据
        using (UnityWebRequest webRequest = UnityWebRequest.Get(googleSheetUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError("Failed to download Google Sheets data: " + webRequest.error);
            }
            else
            {
                // 将下载的数据解析为关卡数据
                ParseGoogleSheetData(webRequest.downloadHandler.text);
            }
        }
    }

    void ParseGoogleSheetData(string sheetData)
    {
        // 打印获取的数据到控制台
        Debug.Log("Google Sheets 数据：" + sheetData);
        LevelList levelList = JsonUtility.FromJson<LevelList>(sheetData);

        // 将 LevelList 中的 levels 赋值给 levelsData
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
        }
        // 更新关卡索引
        currentLevelIndex++;
    }

    IEnumerator LoadScenesAsync(List<string> scenesToLoad)
    {
        // Unload current scene if needed
        if (SceneManager.sceneCount > 1)
        {
            yield return SceneManager.UnloadSceneAsync(SceneManager.GetSceneAt(1).name);
        }

        // Load new scene
        foreach (string sceneName in scenesToLoad)
        {
            AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
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
