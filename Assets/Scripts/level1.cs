using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    public Image okImage;
    public CheckboxController checkboxController;
    public TimerManager timerManager; // 引用计时器管理器
    private bool isPlayerInside = false;

    void Start()
    {
        okImage.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;

            StartCoroutine(ShowImageAndLoadScene());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            // 在玩家離開區域時繼續計時器
            if (timerManager != null)
            {
                timerManager.ResumeTimer();
            }
        }
    }

    IEnumerator ShowImageAndLoadScene()
    {
        if (isPlayerInside)
        {
            checkboxController.TriggerEvent();
            okImage.gameObject.SetActive(true);
            if (timerManager != null)
            {
                timerManager.PauseTimer();
            }

            yield return new WaitForSeconds(4f);

            LevelManager.Instance.LoadNextLevel();

            // 在加载下一个场景后恢复计时器
        }
    }
}
