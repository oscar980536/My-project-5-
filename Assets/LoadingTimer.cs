using UnityEngine;
using UnityEngine.UI;

public class TimerFillAmount : MonoBehaviour
{
    public float duration = 5f; // 计时器持续时间
    public Image fillImage; // 图像填充量对象

    private float timer; // 计时器
    private bool levelLoaded = false; // 是否已加载下一个关卡

    void Start()
    {
        timer = 0f;
        levelLoaded = false;
    }

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 根据计时器的当前值更新填充量
        float fillAmount = timer / duration;
        fillImage.fillAmount = fillAmount;

        // 如果计时器达到持续时间，且还没有加载过下一个关卡，则执行操作
        if (timer >= duration && !levelLoaded)
        {
            LevelManager.Instance.LoadNextLevel();
            levelLoaded = true; // 标记为已加载下一个关卡，避免重复加载
        }
    }
}
