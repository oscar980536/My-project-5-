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

            // �b���a�i�J�ϰ�ɼȰ��p�ɾ�
            StartCoroutine(ShowImageAndLoadScene());
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;

            // �b���a���}�ϰ���~��p�ɾ�
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
