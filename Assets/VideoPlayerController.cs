using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // �q�\�v�����񧹲����ƥ�
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // ��v�����񧹦��ɪ��^�ը��
    void OnVideoFinished(VideoPlayer vp)
    {
        EventCounter.Instance.TriggerEvent();
        LevelManager.Instance.LoadNextLevel();

    }
}
