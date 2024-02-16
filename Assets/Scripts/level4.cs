using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level4 : MonoBehaviour
{
    public Image okImage;
    public CheckboxController checkboxController;
    public TimerManager timerManager; // 引用计时器管理器
    private bool isPlayerInside = false;
    private bool isCoroutineRunning = false;

    void Start()
    {
        okImage.gameObject.SetActive(false);
        // 訂閱 CheckboxController 中的事件
        checkboxController.OnEventTriggered += OnCheckboxEventTriggered;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (!isCoroutineRunning)
            {
                StartCoroutine(ShowImageAndLoadScene());
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (isCoroutineRunning)
            {
                StopCoroutine(ShowImageAndLoadScene());
                isCoroutineRunning = false;
            }
        }
    }

    IEnumerator ShowImageAndLoadScene()
    {
        isCoroutineRunning = true;
        yield return new WaitForSeconds(10f);

        if (isPlayerInside)
        {
            // 觸發 CheckboxController 中的事件
            checkboxController.TriggerEvent();
            if (timerManager != null)
            {
                timerManager.PauseTimer();
            }
            okImage.gameObject.SetActive(true);
            yield return new WaitForSeconds(4f);
            LevelManager.Instance.LoadNextLevel();
        }

        isCoroutineRunning = false;
    }

    // CheckboxController 中的事件被觸發時調用
    void OnCheckboxEventTriggered(int eventTriggerCount)
    {
        // 在這裡處理事件被觸發時的邏輯
    }
}
