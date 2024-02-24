using UnityEngine;
using UnityEngine.UI;

public class EventCounterImageController : MonoBehaviour
{
    public Image image1; // 图片1
    public Image image2; // 图片2
    public Image image3; // 图片3

    private EventCounter eventCounter; // 对 EventCounter 的引用

    private void Start()
    {
        eventCounter = EventCounter.Instance; // 获取 EventCounter 的实例

        // 订阅 EventCounter 的事件，在计数器更新时调用 UpdateImage 方法
        eventCounter.OnEventTriggered += UpdateImage;

        // 初始更新图片
        UpdateImage(eventCounter.GetEventCount());
    }

    // 根据计数器的值更新图片
    private void UpdateImage(int count)
    {
        if (count >= 0 && count <= 3)
        {
            // 显示图片1，隐藏其他图片
            image1.gameObject.SetActive(true);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(false);
        }
        else if (count >= 4 && count <= 8)
        {
            // 显示图片2，隐藏其他图片
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(true);
            image3.gameObject.SetActive(false);
        }
        else if (count == 9)
        {
            // 显示图片3，隐藏其他图片
            image1.gameObject.SetActive(false);
            image2.gameObject.SetActive(false);
            image3.gameObject.SetActive(true);
        }
        // 可以根据需要添加其他条件和图片
    }

    // 在销毁时取消订阅事件，防止内存泄漏
    private void OnDestroy()
    {
        eventCounter.OnEventTriggered -= UpdateImage;
    }
}
