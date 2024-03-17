using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource;
    public float volumeMultiplier = 2f; // 设置音量倍数，例如2表示将音量放大两倍

    void Start()
    {
        // 将音量乘以倍数
        audioSource.volume *= volumeMultiplier;
    }
}
