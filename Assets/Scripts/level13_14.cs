using UnityEngine;
using UnityEngine.UI;

public class level13_14 : MonoBehaviour
{
    public Image okImage;
    public Image bullerImage;
    public SoundController soundController;
    public Button myButton; // 新增的 Button

    void Start()
    {
        okImage.gameObject.SetActive(false);
        bullerImage.gameObject.SetActive(false);
        myButton.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        // 檢查觸發的碰撞器是否是指定的物件
        if (other.CompareTag("Player"))
        {
            okImage.gameObject.SetActive(true);
            bullerImage.gameObject.SetActive(true);
            EventCounter.Instance.TriggerEvent();
            EventCounter.Instance.TriggerEvent();
            soundController?.PlaySound2();
            myButton.gameObject.SetActive(true);
        }
    }
}
