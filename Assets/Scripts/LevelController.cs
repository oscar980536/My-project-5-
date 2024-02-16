using UnityEngine;

public class LevelController : MonoBehaviour
{
    public CheckboxController checkboxController;
    public GameObject image1; // �Ϥ��@
    public GameObject image2; // �Ϥ��G
    public GameObject image3; // �Ϥ��T

    void Start()
    {
        // �q�\ ToggleController �����ƥ�
        checkboxController.OnEventTriggered += CalculateCompletion;

        // �b�}�l�ɱN�Ӥ����]�m�������
        HideImage(image1);
        HideImage(image2);
        HideImage(image3);
    }

    // ����ɩI�s�A�p�⧹����
    public void CalculateCompletion(int eventTriggerCount)
    {
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
