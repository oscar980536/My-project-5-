using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public TextMeshProUGUI timerText;
    public GameObject selectedImage; // 你選擇的顯示圖片的 GameObject
    public float countdownTime = 60f; // 將計時器初始時間設置為public
    public float currentTime; // 將當前時間設置為public
    public bool isTimerPaused = false; // 將計時器暫停狀態設置為public

    private Transform Cameratransform;
    private Vector2 windowOffset = new Vector2(5f, 0.8f);
    public TextAnchor windowAnchor = TextAnchor.LowerCenter;
    private Transform window;
    private float windowFollowSpeed = 10f;
    public float distance = 2.5f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // 如果實例已存在，則銷毀當前對象
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;

        // 初始時尋找主相機的 Transform
        FindMainCameraTransform();

        // 在 Awake 中初始化 window
        window = transform;
    }

    private void Start()
    {
        currentTime = countdownTime;
        UpdateTimerText();

        if (selectedImage != null)
        {
            selectedImage.SetActive(false);
        }
    }

    private void Update()
    {
        if (!isTimerPaused)
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                Debug.Log("Time's up!");
                ShowSelectedImage(); // 顯示選定的圖片
                currentTime = 0f; // 將時間設置為 0，以防止負數顯示
                UpdateTimerText();
                SceneManager.LoadScene("end");
            }
        }

        // 添加相機控制
        if (Cameratransform != null)
        {
            setWindowPositon();
        }
    }
    private void ShowSelectedImage()
    {
        // 在這裡添加顯示選定圖片的程式碼
        // 例如，啟用 selectedImage 物件
        if (selectedImage != null)
        {
            selectedImage.SetActive(true);
        }
    }

    public void PauseTimer()
    {
        isTimerPaused = true;
    }

    public void ResumeTimer()
    {
        isTimerPaused = false;
    }

    public void PauseAndResumeTimer()
    {
        if (isTimerPaused)
        {
            ResumeTimer();
        }
        else
        {
            PauseTimer();
        }
    }

    // 公共Getter方法
    public float GetCurrentTime()
    {
        return currentTime;
    }

    public bool IsTimerPaused()
    {
        return isTimerPaused;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // 在場景加載後重新尋找主相機的 Transform
        FindMainCameraTransform();

        // 在 OnSceneLoaded 中重新初始化 window
        window = transform;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // 恢复计时器，但只有在计时器当前处于暂停状态时才恢复
        if (isTimerPaused)
        {
            ResumeTimer();
        }
    }

    private void FindMainCameraTransform()
    {
        Camera mainCamera = Camera.main;

        if (mainCamera != null)
        {
            Cameratransform = mainCamera.transform;
        }
        else
        {
            Debug.LogWarning("Main camera not found.");
        }
    }

    private void UpdateTimerText()
    {
        if (timerText != null)
        {
            // 如果時間小於零，顯示為 00:00
            if (currentTime < 0f)
            {
                timerText.text = "00:00";
            }
            else
            {
                TimeSpan timeSpan = TimeSpan.FromSeconds(currentTime);
                string formattedTime = string.Format("{0:D2}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
                timerText.text = formattedTime;
            }
        }
    }

    private void setWindowPositon()
    {
        float t = Time.deltaTime * windowFollowSpeed;
        window.transform.position = Vector3.Lerp(window.position, calculateWindowPosition(Cameratransform), t);
        window.rotation = Quaternion.Slerp(window.rotation, Cameratransform.rotation, t);
    }

    private Vector3 calculateWindowPosition(Transform cameraTransform)
    {
        float windowDistance = Mathf.Max(16.0f / Camera.main.fieldOfView, Camera.main.nearClipPlane + distance);
        Vector3 position = Cameratransform.position + (cameraTransform.forward * windowDistance);
        Vector3 horizontalOffset = Cameratransform.right * windowOffset.x;
        Vector3 verticalOffset = Cameratransform.up * windowOffset.y;

        switch (windowAnchor)
        {
            case TextAnchor.UpperLeft: position += verticalOffset - horizontalOffset; break;
            case TextAnchor.UpperCenter: position += verticalOffset; break;
            case TextAnchor.UpperRight: position += verticalOffset + horizontalOffset; break;
            case TextAnchor.MiddleLeft: position -= verticalOffset; break;
            case TextAnchor.MiddleRight: position += verticalOffset; break;
            case TextAnchor.LowerLeft: position -= verticalOffset + horizontalOffset; break;
            case TextAnchor.LowerCenter: position -= verticalOffset; break;
            case TextAnchor.LowerRight: position -= verticalOffset - horizontalOffset; break;
        }
        return position;
    }
}
