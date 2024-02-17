using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 導入 UnityEngine.UI 命名空間以使用 Image
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Image okImage; // 將類型更改為 Image
    public Image loadingImage; // 新增的圖片
    public SoundController soundController;

    void Start()
    {
        // 在最初禁用圖片
        okImage.gameObject.SetActive(false);
        loadingImage.gameObject.SetActive(false); // 隱藏 loadingImage
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(ShowImageAndLoadScene());
            soundController.PlaySound2();
        }
    }

    IEnumerator ShowImageAndLoadScene()
    {
        okImage.gameObject.SetActive(true); // 啟用圖片

        yield return new WaitForSeconds(7f); // 延遲 2 秒

        loadingImage.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);

        // 在這裡加載你的場景
        SceneManager.LoadScene("Scene2(look)");
    }
}
