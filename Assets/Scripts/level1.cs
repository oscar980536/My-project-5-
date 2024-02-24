using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class level1 : MonoBehaviour
{
    public Image okImage;
    public CheckboxController checkboxController;
    public Loading loading; // 引用 LoadingManager 脚本

    void Start()
    {
        okImage.gameObject.SetActive(false);
        loading = FindObjectOfType<Loading>(); // 获取 LoadingManager 实例
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            checkboxController.TriggerEvent();
            okImage.gameObject.SetActive(true);
            EventCounter.Instance.TriggerEvent();
            StartCoroutine(DelayBeforeShowingLoadingImage(2f));
        }
    }

    IEnumerator DelayBeforeShowingLoadingImage(float delay)
    {
        yield return new WaitForSeconds(delay); // 延遲 2 秒
        okImage.gameObject.SetActive(false);
        loading.MovePlayerToTargetPosition();

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
    }

    // 這個方法需要在 level1 類內部定義，以便被其他方法調用
    void MovePlayerToPosition(Vector3 targetPosition)
    {
        // 將玩家移動到目標位置
        // 假設這個類是附加到玩家遊戲物件上
        transform.position = targetPosition;
    }
}
