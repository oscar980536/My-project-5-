using UnityEngine;
using UnityEngine.UI;
using System;

public class LevelController : MonoBehaviour
{
    public Toggle[] toggles; // �q CheckboxController ���ʨ�o��
    private int[] toggleTriggerCounts; // �l�ܨC�� checkbox ��Ĳ�o����

    public GameObject image1; // �Ϥ��@
    public GameObject image2; // �Ϥ��G
    public GameObject image3; // �Ϥ��T

    // �w�q�ƥ�
    public event Action<int> OnEventTriggered;

    void Start()
    {
        toggleTriggerCounts = new int[toggles.Length];

        // �b�}�l�ɱN�Ӥ����]�m�������
        HideImage(image1);
        HideImage(image2);
        HideImage(image3);
    }

    // ����ƱN�b checkbox �QĲ�o�ɳQ�I�s
    public void OnToggleTriggered(int toggleIndex)
    {
        // �W�[ checkbox ��Ĳ�o����
        toggleTriggerCounts[toggleIndex]++;

        // �p��ƥ�Ĳ�o���ƨä޵o�ƥ�
        int eventTriggerCount = 0;
        for (int i = 0; i < toggles.Length; i++)
        {
            eventTriggerCount += toggleTriggerCounts[i];
        }

        // �޵o�ƥ�öǻ��ƥ�Ĳ�o����
        OnEventTriggered?.Invoke(eventTriggerCount);

        // ���� toggle �����A
        foreach (Toggle toggle in toggles)
        {
            if (toggle != null)
            {
                toggle.isOn = !toggle.isOn;
            }
        }

        // �ھڨƥ�Ĳ�o���ƽեΤ��P���Ϥ�
        if (eventTriggerCount >= 0 && eventTriggerCount <= 2)
        {
            ShowImage(image1);
            HideImage(image2);
            HideImage(image3);
        }
        else if (eventTriggerCount >= 3 && eventTriggerCount <= 7)
        {
            ShowImage(image2);
            HideImage(image1);
            HideImage(image3);
        }
        else if (eventTriggerCount == 8)
        {
            ShowImage(image3);
            HideImage(image1);
            HideImage(image2);
        }
    }

    // ��ܹϤ�
    private void ShowImage(GameObject image)
    {
        // �b���B�i����ܹϤ����ާ@
        // �i�H�O�ҥιϤ��C������B�󴫹Ϥ���
        image.SetActive(true);
    }

    // ���ùϤ�
    private void HideImage(GameObject image)
    {
        // �b���B�i�����ùϤ����ާ@
        // �i�H�O�T�ιϤ��C������B�󴫹Ϥ���
        image.SetActive(false);
    }
}
