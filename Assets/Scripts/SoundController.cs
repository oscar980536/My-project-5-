using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();

        // 在进入场景时播放声音1
        PlaySound1();
    }

    // 播放声音1
    void PlaySound1()
    {
        audioSource.clip = sound1;
        audioSource.Play();
    }

    // 播放声音2
    public void PlaySound2()
    {
        // 停止当前正在播放的声音（如果有的话）
        audioSource.Stop();

        // 播放声音2
        audioSource.clip = sound2;
        audioSource.Play();
    }
}