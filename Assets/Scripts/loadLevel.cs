using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadLevel : MonoBehaviour
{
    public void OnButtonClick()
    {
        LevelManager.Instance.LoadNextLevel();
    }
}