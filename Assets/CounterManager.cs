using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CounterManager : MonoBehaviour
{
    private EventCounter eventCounter;
    public TextMeshProUGUI counterText; // 引用UI Text对象

    void Start()
    {
        // 确保UI Text对象被正确引用
        if (counterText == null)
        {
            Debug.LogError("Counter Text is not assigned!");
        }

        // 获取 EventCounter 的引用
        eventCounter = FindObjectOfType<EventCounter>();
        if (eventCounter == null)
        {
            Debug.LogError("EventCounter is not found in the scene!");
        }
    }

    void Update()
    {
        // 更新UI Text上的文本显示
        if (eventCounter != null)
        {
            counterText.text = "恭喜你完成 " + eventCounter.GetEventCount().ToString() + " 個願望";
        }
    }
}
