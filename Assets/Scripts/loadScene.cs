using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Scene1(move)");
    }
}