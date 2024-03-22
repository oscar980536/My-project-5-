using UnityEngine;
using UnityEngine.UI;

public class leaf_action : MonoBehaviour
{
    public Animator leaf_ani02;
    public Image okImage;
    public Image bullerImage;
    public SoundController soundController;
    public Button myButton; // 新增的 Button
    private CharacterController controller;
    private bool isSticky = false;
    private Transform stickyObject;

    void Start()
    {
        okImage.gameObject.SetActive(false);
        bullerImage.gameObject.SetActive(false);
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
        if (isSticky && stickyObject != null)
        {
            // 让Player对象跟随粘附的物体移动
            controller.Move(stickyObject.position - transform.position);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StickyTrigger"))
        {
            isSticky = true;
            stickyObject = other.transform.parent;
            leaf_ani02.SetBool("move", true);
            // 在 OnTriggerEnter 觸發時立即執行這些邏輯
            EventCounter.Instance.TriggerEvent();
            okImage.gameObject.SetActive(true);
            bullerImage.gameObject.SetActive(true);
            soundController?.PlaySound2();
            myButton.gameObject.SetActive(true);
        }
    }
}
