using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontrol : MonoBehaviour
{
    private Vector2 windowOffset = new Vector2(0.2f,0.2f);//偏移量
    public TextAnchor windowAnchor = TextAnchor.LowerCenter;//偏移類型
    private Transform window;//跟隨的窗體
    public Transform Cameratransform;//相機
    private float windowFollowSpeed = 1.5f;//跟隨速度
    public float distance = 0.5f;//跟隨的距離
// Start is called before the first frame update
    protected void Awake()
    {
        window = transform;
        if (Cameratransform == null) Cameratransform = Camera.main.transform;
    }


    private void OnEnable()
    {
        //resetWindowPositon();
    }

    //Update is called once per frame
    private void LateUpdate()
    {
        setWindowPositon();
    }
    private void setWindowPositon()
    {
        float t = Time.deltaTime * windowFollowSpeed;
        window.transform.position = Vector3.Lerp(window.position, calculateWindowPosition(Cameratransform), t);
        window.rotation = Quaternion.Slerp(window.rotation, Cameratransform.rotation, t);
    }

    private Vector3 calculateWindowPosition(Transform cameraTransform)
    {
        float windowDistance = Mathf.Max(16.0f / Camera.main.fieldOfView,Camera.main.nearClipPlane + distance);
        Vector3 position = Cameratransform.position + (cameraTransform.forward * windowDistance);
        Vector3 horizontalOffset = Cameratransform.right * windowOffset.x;
        Vector3 verticalOffset = Cameratransform.up * windowOffset.y;

        switch (windowAnchor)
        {
            case TextAnchor.UpperLeft : position += verticalOffset - horizontalOffset; break;
            case TextAnchor.UpperCenter : position += verticalOffset; break;
            case TextAnchor.UpperRight : position += verticalOffset + horizontalOffset; break;
            case TextAnchor.MiddleLeft : position -= verticalOffset; break;
            case TextAnchor.MiddleRight: position += verticalOffset; break;
            case TextAnchor.LowerLeft : position -= verticalOffset + horizontalOffset; break;
            case TextAnchor.LowerCenter : position -= verticalOffset; break;
            case TextAnchor.LowerRight : position -= verticalOffset - horizontalOffset; break;
        }
        return position;
    }

}
