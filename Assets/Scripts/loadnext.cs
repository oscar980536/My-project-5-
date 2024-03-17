using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadnext : MonoBehaviour
{
    public void OnButtonClick()
    {
        SceneManager.LoadScene("Scene2(look)");
    }
}