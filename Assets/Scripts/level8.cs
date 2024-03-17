﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class level8 : MonoBehaviour
{
    // 儲存與蜜蜂互動的動畫
    public Animator Bee_ani_patch_01;
    public Animator spider_ani01;
    public Image okImage;
    public SoundController soundController;
    public Button myButton; // 新增的 Button


    void Start()
    {
        okImage.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Bee_ani_patch_01.SetBool("Fly", true);
            spider_ani01.SetBool("spider_fly", true);

            // 在 OnTriggerEnter 觸發時立即執行這些邏輯
            EventCounter.Instance.TriggerEvent();
            okImage.gameObject.SetActive(true);
            soundController?.PlaySound2();
            myButton.gameObject.SetActive(true);
        }
    }
}