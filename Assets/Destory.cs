using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Destroyer : MonoBehaviour
{
    /// <summary>
    /// ��ҹ���
    /// </summary>
    private static Destroyer instance;

    /// <summary>
    /// �Q�[�J�b DontDestroyOnLoad ���C������
    /// </summary>
    private static List<GameObject> indestructibleGameObjects;

    /// <summary>
    /// ��ҹ���
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
    /// �P DontDestroyOnLoad ���|��������ΨӺ޲z
    /// </summary>
    /// <param name="_gameObject"></param>
    public void DontDestroyOnLoad(GameObject _gameObject)
    {
        indestructibleGameObjects.Add(_gameObject);

        Object.DontDestroyOnLoad(_gameObject);
    }

    /// <summary>
    /// �N DontDestroyOnLoad �������C�����󲾨��e�����A���C������i�H�Q�M���C
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