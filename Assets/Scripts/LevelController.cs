using UnityEngine;

public class LevelController : MonoBehaviour
{
    public CheckboxController checkboxController;
    public GameObject image1; // 圖片一
    public GameObject image2; // 圖片二
    public GameObject image3; // 圖片三

    void Start()
    {
        // 訂閱 ToggleController 中的事件
        checkboxController.OnEventTriggered += CalculateCompletion;

        // 在開始時將照片都設置為不顯示
        HideImage(image1);
        HideImage(image2);
        HideImage(image3);
    }

    // 結算時呼叫，計算完成度
    public void CalculateCompletion(int eventTriggerCount)
    {
        // 根據事件觸發次數調用不同的圖片
        if (eventTriggerCount >= 0 && eventTriggerCount <= 2)
        {
            ShowImage(image1);
            HideImage(image2);
            HideImage(image3);
        }
        else if (eventTriggerCount >= 3 && eventTriggerCount <= 7)
        {
            ShowImage(image2);
            HideImage(image1);
            HideImage(image3);
        }
        else if (eventTriggerCount == 8)
        {
            ShowImage(image3);
            HideImage(image1);
            HideImage(image2);
        }
    }

    // 顯示圖片
    private void ShowImage(GameObject image)
    {
        // 在此處進行顯示圖片的操作
        // 可以是啟用圖片遊戲物件、更換圖片等
        image.SetActive(true);
    }

    // 隱藏圖片
    private void HideImage(GameObject image)
    {
        // 在此處進行隱藏圖片的操作
        // 可以是禁用圖片遊戲物件、更換圖片等
        image.SetActive(false);
    }
}
