using UnityEngine;

public class stop : MonoBehaviour
{
    public TimerManager timerManager;
    public LevelManager levelManager;

    private void Start()
    {
        // ���A�۰ʰ��κ޲z���A�ӬO��ʽեλݭn���Ϊ��ɭ�
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

        // ���� DontDestroyOnLoad ������
        GameObject[] dontDestroyObjects = GameObject.FindGameObjectsWithTag("DontDestroyOnLoad");
        foreach (GameObject obj in dontDestroyObjects)
        {
            obj.SetActive(false);
        }
    }
}
