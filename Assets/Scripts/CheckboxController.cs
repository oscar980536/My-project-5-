using UnityEngine;
using UnityEngine.UI;
using System;

public class CheckboxController : MonoBehaviour
{
    public Toggle checkbox;
    private int eventTriggerCount = 0;

    public event Action<int> OnEventTriggered;

    void Start()
    {
        // �T�O checkbox ���Q�w�]�Ŀ�
        if (checkbox != null)
        {
            checkbox.isOn = false;
        }
    }

    // ����ƱN�b�ƥ�Ĳ�o�ɳQ�I�s
    public void TriggerEvent()
    {
        // �ˬd checkbox �O�_�s�b�ñN�䥴��
        if (checkbox != null)
        {
            checkbox.isOn = true; // �Y�n�����Ŀ�A�ϥ� checkbox.isOn = false;
        }

        // �W�[�ƥ�Ĳ�o����
        eventTriggerCount++;

        // Ĳ�o�ƥ�A�ǻ��ƥ�Ĳ�o����
        OnEventTriggered?.Invoke(eventTriggerCount);
    }
}
