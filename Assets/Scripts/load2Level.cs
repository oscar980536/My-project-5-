using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class load2Level : MonoBehaviour
{
    public void OnButtonClick()
    {
        EventCounter.Instance.TriggerEvent();
        EventCounter.Instance.TriggerEvent();
        LevelManager.Instance.LoadNextLevel();
    }
}
