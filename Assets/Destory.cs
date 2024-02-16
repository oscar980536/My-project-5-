using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    /// <summary>
    /// 單例實體
    /// </summary>
    private static Destroyer instance;

    /// <summary>
    /// 被加入在 DontDestroyOnLoad 的遊戲物件
    /// </summary>
    private static List<GameObject> indestructibleGameObjects;

    /// <summary>
    /// 單例實體
    /// </summary>
    public static Destroyer Instance
    {
        get => instance;
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);

            return;
        }
        instance = this;
        DontDestroyOnLoad(instance);
        indestructibleGameObjects = new();
    }
    private void Start()
    {
        Destroyer.Instance.DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// 同 DontDestroyOnLoad 但會紀錄物件用來管理
    /// </summary>
    /// <param name="_gameObject"></param>
    public void DontDestroyOnLoad(GameObject _gameObject)
    {
        indestructibleGameObjects.Add(_gameObject);

        Object.DontDestroyOnLoad(_gameObject);
    }

    /// <summary>
    /// 將 DontDestroyOnLoad 場景的遊戲物件移到當前場景，讓遊戲物件可以被清除。
    /// </summary>
    public void MoveGameObjects()
    {
        while (indestructibleGameObjects.Count > 0)
        {
            GameObject _gameObject = indestructibleGameObjects[0];
            indestructibleGameObjects.RemoveAt(0);

            SceneManager.MoveGameObjectToScene(_gameObject, SceneManager.GetActiveScene());
        }
    }
}