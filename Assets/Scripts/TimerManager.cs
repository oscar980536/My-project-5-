﻿using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class TimerManager : MonoBehaviour
{
    public static TimerManager Instance;

    public TextMeshProUGUI timerText;
    public float countdownTime = 60f;
    public float currentTime;
    public bool isTimerPaused = false;

    private Transform Cameratransform;
    private Vector2 windowOffset = new Vector2(5f, 0.8f);
    public TextAnchor windowAnchor = TextAnchor.LowerCenter;
    private Transform window;
    private float windowFollowSpeed = 10f;
    public float distance = 2.5f;

    private bool timerActive = true; // 新增一個標誌來指示計時器是否處於活動狀態

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        SceneManager.sceneLoaded += OnSceneLoaded;
        FindMainCameraTransform();
        window = transform;
    }

    private void Start()
    {
        currentTime = countdownTime;
        UpdateTimerText();
    }

    private void Update()
    {
        if (!isTimerPaused && timerActive) // 增加條件以檢查計時器是否仍然應該更新
        {
            if (currentTime > 0f)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerText();
            }
            else
            {
                Debug.Log("Time's up!");
                currentTime = 0f;
                UpdateTimerText();
                SceneManager.LoadScene("end");
                timerActive = false; // 設置標誌為false，停止計時器更新
            }
        }

        if (Cameratransform != null)
        {
            setWindowPositon();
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
        FindMainCameraTransform();
        window = transform;

        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

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
