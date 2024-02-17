#region Includes
using System.Collections;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
#endregion

namespace TS.GazeInteraction
{
    /// <summary>
    /// Component applied to GameObjects that can be interacted with using the gaze.
    /// </summary>
    public class GazeInteractable : MonoBehaviour
    {
        #region Variables

        private const string WAIT_TO_EXIT_COROUTINE = "WaitToExit_Coroutine";

        public delegate void OnEnter(GazeInteractable interactable, GazeInteractor interactor, Vector3 point);
        public event OnEnter Enter;

        public delegate void OnStay(GazeInteractable interactable, GazeInteractor interactor, Vector3 point);
        public event OnStay Stay;

        public delegate void OnExit(GazeInteractable interactable, GazeInteractor interactor);
        public event OnExit Exit;

        public delegate void OnActivated(GazeInteractable interactable);
        public event OnActivated Activated;

        public CheckboxController checkboxController;
        public TimerManager timerManager; // 引用計時器管理器

        [Header("Configuration")]
        [SerializeField] private bool _isActivable;
        [SerializeField] private float _exitDelay;
        [SerializeField] public Image successImage;
        [SerializeField] public Image loadingImage; // 新增的圖片
        [SerializeField] public float displayDuration = 6f;
        [SerializeField] public SoundController soundController;

        [Header("Events")]
        public UnityEvent OnGazeEnter;
        public UnityEvent OnGazeStay;
        public UnityEvent OnGazeExit;
        public UnityEvent OnGazeActivated;
        public UnityEvent<bool> OnGazeToggle;


        public bool IsEnabled
        {
            get { return _collider.enabled; }
            set { _collider.enabled = value; }
        }
        public bool IsActivable
        {
            get { return _isActivable; }
        }
        public bool IsActivated { get; private set; }

        private Collider _collider;

        #endregion

        private void Awake()
        {
            _collider = GetComponent<Collider>();

#if UNITY_EDITOR || DEVELOPMENT_BUILD
            if (_collider == null) { throw new System.Exception("Missing Collider"); }
#endif
        }

        private void Start()
        {
            enabled = false;
            successImage?.gameObject.SetActive(false); // 開始時禁用圖片
            loadingImage?.gameObject.SetActive(false); // 隱藏 loadingImage
        }

        /// <summary>
        ///  Toggles the GameObject.
        /// </summary>
        /// <param name="enable"></param>
        public void Enable(bool enable)
        {
            gameObject.SetActive(enable);
        }

        /// <summary>
        /// Invokes the Activated events.
        /// </summary>
        public void Activate()
        {
            IsActivated = true;

            Activated?.Invoke(this);
            OnGazeActivated?.Invoke();
            soundController?.PlaySound2();
            checkboxController?.TriggerEvent();
            timerManager?.PauseTimer();

            successImage?.gameObject.SetActive(true); // 啟用 Image 顯示
            StartCoroutine(HideSuccessImageAfterDelayAndLoadScene());
        }

        private IEnumerator HideSuccessImageAfterDelayAndLoadScene()
        {
            checkboxController?.TriggerEvent();

            // 等待指定時間
            yield return new WaitForSeconds(displayDuration);

            // 隱藏 Image
            successImage?.gameObject.SetActive(false);
            loadingImage?.gameObject.SetActive(true);
            yield return new WaitForSeconds(2F);

            // 加載下一個場景
            LoadNextScene();
        }

        private void LoadNextScene()
        {
            LevelManager.Instance.LoadNextLevel();
        }

        /// <summary>
        /// Called by the GazeInteractor when the gaze enters this Interactable.
        /// Invokes the Enter events.
        /// </summary>
        /// <param name="interactor"></param>
        /// <param name="point"></param>
        public void GazeEnter(GazeInteractor interactor, Vector3 point)
        {
            StopCoroutine(WAIT_TO_EXIT_COROUTINE);

            Enter?.Invoke(this, interactor, point);

            OnGazeEnter?.Invoke();
            OnGazeToggle?.Invoke(true);
        }

        /// <summary>
        /// Called by the GazeInteractor while the gaze stays on top of this Interactable.
        /// Invokes the Stay events.
        /// </summary>
        /// <param name="interactor"></param>
        /// <param name="point"></param>
        public void GazeStay(GazeInteractor interactor, Vector3 point)
        {
            Stay?.Invoke(this, interactor, point);

            OnGazeStay?.Invoke();
        }

        /// <summary>
        /// Called by the GazeInteractor when the gaze exits this Interactable.
        /// Invokes the Exit events.
        /// </summary>
        /// <param name="interactor"></param>
        public void GazeExit(GazeInteractor interactor)
        {
            if (gameObject.activeInHierarchy)
            {
                StartCoroutine(WaitToExit_Coroutine(interactor));
            }
            else
            {
                InvokeExit(interactor);
            }
        }

        private IEnumerator WaitToExit_Coroutine(GazeInteractor interactor)
        {
            yield return new WaitForSeconds(_exitDelay);

            InvokeExit(interactor);
        }

        private void InvokeExit(GazeInteractor interactor)
        {
            Exit?.Invoke(this, interactor);

            OnGazeExit?.Invoke();
            OnGazeToggle?.Invoke(false);

            IsActivated = false;
        }
    }
}
