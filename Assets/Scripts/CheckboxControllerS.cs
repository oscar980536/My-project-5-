using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckboxControllers : MonoBehaviour
{
    public Toggle checkbox1;
    public Toggle checkbox2;
    private int checkbox1Count = 0;
    private int checkbox2Count = 0;

    public event Action<int, int> OnEventTriggered;

    void Start()
    {
        // �T�O checkbox ���Q�w�]�Ŀ�
        if (checkbox1 != null)
        {
            checkbox1.isOn = false;
        }
        if (checkbox2 != null)
        {
            checkbox2.isOn = false;
        }
    }

    // ����ƱN�b�ƥ�Ĳ�o�ɳQ�I�s
    public void TriggerEvent()
    {
        // �ˬd checkbox1 �O�_�s�b�íp��Ŀ隸��
        if (checkbox1 != null && !checkbox1.isOn)
        {
            checkbox1Count++;
            checkbox1.isOn = true;
        }

        // �ˬd checkbox2 �O�_�s�b�íp��Ŀ隸��
        if (checkbox2 != null && !checkbox2.isOn)
        {
            checkbox2Count++;
            checkbox2.isOn = true;
        }

        // Ĳ�o�ƥ�A�ǻ���� checkbox ���Ŀ隸��
        OnEventTriggered?.Invoke(checkbox1Count, checkbox2Count);
    }
}
