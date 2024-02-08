using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level1 : MonoBehaviour
{
    public Image okImage;
    private bool isPlayerInside = false;

    void Start()
    {
        okImage.gameObject.SetActive(false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = true;

            // 在玩家進入區域時暫停計時器
            StartCoroutine(ShowImageAndLoadScene());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            // 在玩家離開區域時繼續計時器
            {
            }
        }
    }

    IEnumerator ShowImageAndLoadScene()
    {
        yield return new WaitForSeconds(3f);

        if (isPlayerInside)
        {
            okImage.gameObject.SetActive(true);

            yield return new WaitForSeconds(4f);

            LevelManager.Instance.LoadNextLevel();
        }
    }
}
