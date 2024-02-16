using UnityEngine;

public class CheckboxManager : MonoBehaviour
{
    public static CheckboxManager Instance; // 單例實例

    public int checkboxEventCount = 0; // 儲存 checkbox 觸發的計數

    private void Awake()
    {
        // 確保只有一個實例存在
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // 在 checkbox 被觸發時更新計數
    public void IncrementCheckboxEventCount()
    {
        checkboxEventCount++;
    }
}
