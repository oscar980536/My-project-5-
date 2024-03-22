using UnityEngine;
using UnityEngine.UI;

public class TimerFillAmount : MonoBehaviour
{
    public float duration = 5f; // 计时器持续时间
    public Image fillImage; // 图像填充量对象

    private float timer; // 计时器

    void Start()
    {
        timer = 0f;
    }

    void Update()
    {
        // 更新计时器
        timer += Time.deltaTime;

        // 根据计时器的当前值更新填充量
        float fillAmount = timer / duration;
        fillImage.fillAmount = fillAmount;

        // 如果计时器达到持续时间，可以在此执行其他操作
        if (timer >= duration)
        {
            LevelManager.Instance.LoadNextLevel();
        }
    }
}
