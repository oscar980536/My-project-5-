using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4 : MonoBehaviour
{
    public Image okImage;
    public Image loadingImage; // 新增的圖片
    public CheckboxController checkboxController;
    public TimerManager timerManager; // 引用计时器管理器
    private bool isPlayerInside = false;
    private bool isShowingImage = false;

    void Start()
    {
        okImage.gameObject.SetActive(false);
        loadingImage.gameObject.SetActive(false); // 隱藏 loadingImage
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (!isShowingImage)
            {
                Invoke("ShowImageAndLoadScene", 10f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (isShowingImage)
            {
                CancelInvoke("ShowImageAndLoadScene");
                isShowingImage = false;
            }
        }
    }

    void ShowImageAndLoadScene()
    {
        if (isPlayerInside)
        {
            // 觸發 CheckboxController 中的事件
            checkboxController.TriggerEvent();
            okImage.gameObject.SetActive(true);
            if (timerManager != null)
            {
                timerManager.PauseTimer();
            }
            StartCoroutine(DelayBeforeShowingLoadingImage(2f));
        }
    }

    IEnumerator DelayBeforeShowingLoadingImage(float delay)
    {
        yield return new WaitForSeconds(delay); // 延遲 2 秒

        // 顯示 loadingImage
        loadingImage.gameObject.SetActive(true);

        // 延遲 2 秒後加載下一個場景
        StartCoroutine(DelayedSceneLoad(2f));
    }

    IEnumerator DelayedSceneLoad(float delay)
    {
        yield return new WaitForSeconds(delay);

        // 加載下一個場景
        LoadNextScene();
    }


    void LoadNextScene()
    {
        // 加載下一個場景
        LevelManager.Instance.LoadNextLevel();
        // 在加载下一个场景后恢复计时器
    }
}