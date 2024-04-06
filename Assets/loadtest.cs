using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class loadtest : MonoBehaviour
{
    public void OnButtonClick()
    {
        LevelManager.Instance.LoadNextLevel();
    }
}
