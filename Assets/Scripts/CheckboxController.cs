using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckboxController : MonoBehaviour
{
    public Toggle checkbox;
    private int eventTriggerCount = 0;

    public event Action<int> OnEventTriggered;

    void Start()
    {
        // 確保 checkbox 不被預設勾選
        if (checkbox != null)
        {
            checkbox.isOn = false;
        }
    }

    // 此函數將在事件觸發時被呼叫
    public void TriggerEvent()
    {
        // 檢查 checkbox 是否存在並將其打勾
        if (checkbox != null)
        {
            checkbox.isOn = true; // 若要取消勾選，使用 checkbox.isOn = false;
        }

        // 增加事件觸發次數
        eventTriggerCount++;

        // 觸發事件，傳遞事件觸發次數
        OnEventTriggered?.Invoke(eventTriggerCount);
    }
}
