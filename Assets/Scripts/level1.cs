using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class level1 : MonoBehaviour
{
    public Image okImage;
    public Image loadingImage; // 新增的圖片
    public CheckboxController checkboxController;
    public TimerManager timerManager; // 引用计时器管理器

    void Start()
    {
        okImage.gameObject.SetActive(false);
        loadingImage.gameObject.SetActive(false); // 隱藏 loadingImage
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
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
        if (timerManager != null)
        {
            timerManager.PauseTimer();
        }

        // 加載下一個場景
        LevelManager.Instance.LoadNextLevel();
    }
}
