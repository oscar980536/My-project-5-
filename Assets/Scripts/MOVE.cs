using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Game Objects
    [SerializeField] private GameObject LeftHand;
    [SerializeField] private GameObject RightHand;
    [SerializeField] private GameObject MainCamera;
    [SerializeField] private GameObject ForwardDirection;

    //Vector3 Positions
    [SerializeField] private Vector3 PositionPreviousFrameLeftHand;
    [SerializeField] private Vector3 PositionPreviousFrameRightHand;
    [SerializeField] private Vector3 PlayerPositionPreviousFrame;
    [SerializeField] private Vector3 PlayerPositionCurrentFrame;
    [SerializeField] private Vector3 PositionCurrentFrameLeftHand;
    [SerializeField] private Vector3 PositionCurrentFrameRightHand;

    //Speed
    [SerializeField] private float Speed = 170;
    [SerializeField] private float HandSpeed;

    void Start()
    {
        PlayerPositionPreviousFrame = transform.position; // 设置当前位置
        PositionPreviousFrameLeftHand = LeftHand.transform.position; // 设置上一帧手的位置
        PositionPreviousFrameRightHand = RightHand.transform.position;
     
    }

    // Update is called once per frame
    void Update()
    {
        // 获取中心眼睛摄像机的前进方向并将其设置为前进方向对象
        float yRotation = MainCamera.transform.eulerAngles.y;
        ForwardDirection.transform.eulerAngles = new Vector3(0, yRotation, 0);

        // 获取手的位置
        PositionCurrentFrameLeftHand = LeftHand.transform.position;
        PositionCurrentFrameRightHand = RightHand.transform.position;

        // 玩家的位置
        PlayerPositionCurrentFrame = transform.position;

        // 计算手和玩家从上一帧到当前帧的移动距离
        var playerDistanceMoved = Vector3.Distance(PlayerPositionCurrentFrame, PlayerPositionPreviousFrame);
        var leftHandDistanceMoved = Vector3.Distance(PositionPreviousFrameLeftHand, PositionCurrentFrameLeftHand);
        var rightHandDistanceMoved = Vector3.Distance(PositionPreviousFrameRightHand, PositionCurrentFrameRightHand);

        // 综合得到手的速度
        HandSpeed = ((leftHandDistanceMoved - playerDistanceMoved) + (rightHandDistanceMoved - playerDistanceMoved));

        // 检查左手和右手是否同时移动
        bool bothHandsMoving = leftHandDistanceMoved > 0.05f && rightHandDistanceMoved > 0.05f;

        if (Time.timeSinceLevelLoad > 1f && bothHandsMoving)
        {
            transform.position += ForwardDirection.transform.forward * HandSpeed * Speed * Time.deltaTime;
        }

        // 设置手的前一帧位置，供下一帧使用
        PositionPreviousFrameLeftHand = PositionCurrentFrameLeftHand;
        PositionPreviousFrameRightHand = PositionCurrentFrameRightHand;

        // 设置玩家前一帧位置
        PlayerPositionPreviousFrame = PlayerPositionCurrentFrame;
    }
}
