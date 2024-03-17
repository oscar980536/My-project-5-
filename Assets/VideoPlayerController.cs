using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
public class VideoPlayerController : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    void Start()
    {
        // 訂閱影片播放完畢的事件
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // 當影片播放完成時的回調函數
    void OnVideoFinished(VideoPlayer vp)
    {
        EventCounter.Instance.TriggerEvent();
        LevelManager.Instance.LoadNextLevel();

    }
}
