using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level4 : MonoBehaviour
{
    public Image okImage;
    public Image bullerImage;
    public SoundController soundController;
    public Button myButton; // 新增的 Button
    private bool isPlayerInside = false;
    private bool isShowingImage = false;

    void Start()
    {
        okImage.gameObject.SetActive(false);
        bullerImage.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;
            if (!isShowingImage)
            {
                Invoke("ShowImageAndLoadScene", 10f);
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            if (isShowingImage)
            {
                CancelInvoke("ShowImageAndLoadScene");
                isShowingImage = false;
            }
        }
    }

    void ShowImageAndLoadScene()
    {
        if (isPlayerInside)
        {
            // 觸發 CheckboxController 中的事件
            okImage.gameObject.SetActive(true);
            bullerImage.gameObject.SetActive(true);
            soundController?.PlaySound2();
            myButton.gameObject.SetActive(true);
        }
    }
}

