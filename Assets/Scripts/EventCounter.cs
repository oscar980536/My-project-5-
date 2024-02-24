using System;
using UnityEngine;

public class EventCounter : MonoBehaviour
{
    private static EventCounter instance; // 单例实例
    private int eventCount = 0; // 记录事件触发次数

    public event Action<int> OnEventTriggered; // 定义事件，在事件触发时传递触发次数

    // 获取单例实例
    public static EventCounter Instance
    {
        get
        {
            // 如果实例不存在，则创建一个新的实例
            if (instance == null)
            {
                GameObject obj = new GameObject("EventCounter");
                instance = obj.AddComponent<EventCounter>();
                DontDestroyOnLoad(obj); // 保留在场景切换时不销毁
            }
            return instance;
        }
    }

    private void Awake()
    {
        // 如果实例已经存在，则销毁新的实例
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject); // 保留在场景切换时不销毁
    }

    // 在事件触发时调用此方法
    public void TriggerEvent()
    {
        eventCount++; // 增加事件触发次数

        // 触发事件，将触发次数传递给订阅者
        OnEventTriggered?.Invoke(eventCount);

        // 输出事件触发次数到控制台
        Debug.Log("Event triggered! Event count: " + eventCount);
    }

    // 获取事件触发次数
    public int GetEventCount()
    {
        return eventCount;
    }
}
