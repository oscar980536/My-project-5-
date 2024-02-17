using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckboxControllers : MonoBehaviour
{
    public Toggle checkbox1;
    public Toggle checkbox2;
    private int checkbox1Count = 0;
    private int checkbox2Count = 0;

    public event Action<int, int> OnEventTriggered;

    void Start()
    {
        // 確保 checkbox 不被預設勾選
        if (checkbox1 != null)
        {
            checkbox1.isOn = false;
        }
        if (checkbox2 != null)
        {
            checkbox2.isOn = false;
        }
    }

    // 此函數將在事件觸發時被呼叫
    public void TriggerEvent()
    {
        // 檢查 checkbox1 是否存在並計算勾選次數
        if (checkbox1 != null && !checkbox1.isOn)
        {
            checkbox1Count++;
            checkbox1.isOn = true;
        }

        // 檢查 checkbox2 是否存在並計算勾選次數
        if (checkbox2 != null && !checkbox2.isOn)
        {
            checkbox2Count++;
            checkbox2.isOn = true;
        }

        // 觸發事件，傳遞兩個 checkbox 的勾選次數
        OnEventTriggered?.Invoke(checkbox1Count, checkbox2Count);
    }
}
