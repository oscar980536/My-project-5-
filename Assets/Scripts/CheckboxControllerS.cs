using UnityEngine;
using UnityEngine.UI;

public class CheckboxControllers : MonoBehaviour
{
    public Toggle checkbox1;
    public Toggle checkbox2;

    void Start()
    {
        // 确保 checkbox 不被默认勾选
        if (checkbox1 != null)
        {
            checkbox1.isOn = false;
        }
        if (checkbox2 != null)
        {
            checkbox2.isOn = false;
        }
    }

    // 此函数将在事件触发时被调用
    public  void TriggerEvent()
    {
        // 检查 checkbox1 是否存在并勾选
        if (checkbox1 != null)
        {
            checkbox1.isOn = true; // 若要取消勾选，使用 checkbox.isOn = false;
        }

        // 检查 checkbox2 是否存在并勾选
        if (checkbox2 != null)
        {
            checkbox2.isOn = true; // 若要取消勾选，使用 checkbox.isOn = false;
        }
    }
}
