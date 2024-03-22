using System.Collections;
using UnityEngine;
using UnityEngine.UI; // 導入 UnityEngine.UI 命名空間以使用 Image
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public Image okImage; // 將類型更改為 Image
    public Image bullerImage;
    public SoundController soundController;
    public Button myButton; // 新增的 Button


    void Start()
    {
        // 在最初禁用圖片
        okImage.gameObject.SetActive(false);
        bullerImage.gameObject.SetActive(false);
        myButton.gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            okImage.gameObject.SetActive(true);
            bullerImage.gameObject.SetActive(true);
            soundController?.PlaySound2();
            myButton.gameObject.SetActive(true);
        }
    }
}
