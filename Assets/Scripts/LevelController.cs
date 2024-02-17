using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    public Toggle[] toggles; // 從 CheckboxController 移動到這裡
    private int[] toggleTriggerCounts; // 追蹤每個 checkbox 的觸發次數

    public GameObject image1; // 圖片一
    public GameObject image2; // 圖片二
    public GameObject image3; // 圖片三

    // 定義事件
    public event Action<int> OnEventTriggered;

    void Start()
    {
        toggleTriggerCounts = new int[toggles.Length];

        // 在開始時將照片都設置為不顯示
        HideImage(image1);
        HideImage(image2);
        HideImage(image3);
    }

    // 此函數將在 checkbox 被觸發時被呼叫
    public void OnToggleTriggered(int toggleIndex)
    {
        // 增加 checkbox 的觸發次數
        toggleTriggerCounts[toggleIndex]++;

        // 計算事件觸發次數並引發事件
        int eventTriggerCount = 0;
        for (int i = 0; i < toggles.Length; i++)
        {
            eventTriggerCount += toggleTriggerCounts[i];
        }

        // 引發事件並傳遞事件觸發次數
        OnEventTriggered?.Invoke(eventTriggerCount);

        // 切換 toggle 的狀態
        foreach (Toggle toggle in toggles)
        {
            if (toggle != null)
            {
                toggle.isOn = !toggle.isOn;
            }
        }

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
