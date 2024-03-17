using UnityEngine;
using UnityEngine.UI;

public class EventCounterImageController : MonoBehaviour
{
    public Image image1; // 圖片1
    public Image image2; // 圖片2
    public Image image3; // 圖片3

    public AudioClip sound1; // 聲音1
    public AudioClip sound2; // 聲音2
    public AudioClip sound3; // 聲音3


    private EventCounter eventCounter; // 對 EventCounter 的引用
    private AudioSource audioSource; // 聲音源

    private void Start()
    {
        eventCounter = EventCounter.Instance; // 獲取 EventCounter 的實例
        audioSource = GetComponent<AudioSource>(); // 獲取 AudioSource

        // 訂閱 EventCounter 的事件，在計數器更新時調用 UpdateImage 方法
        eventCounter.OnEventTriggered += UpdateImage;

        // 初始化更新圖片和聲音
        UpdateImage(eventCounter.GetEventCount());
    }

    // 根據計數器的值更新圖片和播放對應的聲音
    private void UpdateImage(int count)
    {
        if (count >= 0 && count <= 3)
        {
            // 顯示圖片1，隱藏其他圖片
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);

            // 播放聲音1
            PlaySound(sound1);
        }
        else if (count >= 4 && count <= 8)
        {
            // 顯示圖片2，隱藏其他圖片
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false);

            // 播放聲音2
            PlaySound(sound2);
        }
        else if (count == 9)
        {
            // 顯示圖片3，隱藏其他圖片
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(true);

            PlaySound(sound3);

        }
        // 可以根據需要添加其他條件和圖片
    }

    // 播放聲音
    private void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}
