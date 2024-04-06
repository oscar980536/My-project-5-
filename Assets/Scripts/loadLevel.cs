using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loadLevel : MonoBehaviour
{
    public void OnButtonClick()
    {
            EventCounter.Instance.TriggerEvent();
            LevelManager.Instance.LoadNextLevel();
    }
}
