using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bee_action : MonoBehaviour
{
    // 儲存與蜜蜂互動的動畫
    public Animator Bee_ani_patch_01;
    public Animator spider_ani01;
    public Image okImage;
    public Image loadingImage; // 新增的圖片
    public CheckboxController checkboxController;

    void Start()
    {
        okImage.gameObject.SetActive(false);
        loadingImage.gameObject.SetActive(false); // 隱藏 loadingImage
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bee_ani_patch_01.SetBool("Fly", true);
            spider_ani01.SetBool("spider_fly", true);

            // 在 OnTriggerEnter 觸發時立即執行這些邏輯
            checkboxController.TriggerEvent();
            EventCounter.Instance.TriggerEvent();
            EventCounter.Instance.TriggerEvent(); // 增加第二次触发
            okImage.gameObject.SetActive(true);

            // 延遲 2 秒後顯示 loadingImage
            StartCoroutine(DelayBeforeShowingLoadingImage(2f));
        }
    }

    IEnumerator DelayBeforeShowingLoadingImage(float delay)
    {
        yield return new WaitForSeconds(delay); // 延遲 2 秒

        // 顯示 loadingImage
        okImage.gameObject.SetActive(false);
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
