using TMPro.Examples;
using UnityEngine;

public class Loading : MonoBehaviour
{
    public GameObject playerObject; // 玩家物体

    // 旋转速度
    public float rotationSpeed = 5f;

    public void MovePlayerToPosition(Vector3 targetPosition)
    {
        // 计算移动方向
        Vector3 direction = targetPosition - playerObject.transform.position;
        direction.y = 0f; // 确保只在水平方向上旋转

        // 将物体朝向目标位置的方向
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            playerObject.transform.rotation = Quaternion.Slerp(playerObject.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        // 将玩家移动到目标位置
        playerObject.transform.position = targetPosition;
    }

    // 新增方法，直接将玩家移动到指定位置并朝向前方
    public void MovePlayerToTargetPosition()
    {
        Vector3 targetPosition = new Vector3(1.6f, -107.4f, -87.5f);
        MovePlayerToPosition(targetPosition);
    }
}
