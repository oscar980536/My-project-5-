using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneEntrance : MonoBehaviour
{
    private void Awake()
    {
        stopuse stopUseScript = FindObjectOfType<stopuse>();
        if (stopUseScript != null)
        {
            stopUseScript.DisableManagersAndDontDestroyObjects();
        }
    }
}

public class stopuse : MonoBehaviour
{
    public TimerManager timerManager;
    public LevelManager levelManager;

    private void Start()
    {
        // 不再自动停用管理器，而是手动调用需要停用的时候
    }

    public void DisableManagersAndDontDestroyObjects()
    {
        if (timerManager != null)
        {
            timerManager.gameObject.SetActive(false);
        }

        if (levelManager != null)
        {
            levelManager.gameObject.SetActive(false);
        }

        // 停用 DontDestroyOnLoad 的物件
        GameObject[] dontDestroyObjects = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        foreach (GameObject obj in dontDestroyObjects)
        {
            obj.SetActive(false);
        }
    }
}
