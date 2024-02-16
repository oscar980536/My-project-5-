using UnityEngine;

public class stop : MonoBehaviour
{
    public TimerManager timerManager;
    public LevelManager levelManager;

    private void Start()
    {
        // 不再自動停用管理器，而是手動調用需要停用的時候
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
