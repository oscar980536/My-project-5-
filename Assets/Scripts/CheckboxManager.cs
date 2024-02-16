using UnityEngine;

public class CheckboxManager : MonoBehaviour
{
    public static CheckboxManager Instance; // ��ҹ��

    public int checkboxEventCount = 0; // �x�s checkbox Ĳ�o���p��

    private void Awake()
    {
        // �T�O�u���@�ӹ�Ҧs�b
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // �b checkbox �QĲ�o�ɧ�s�p��
    public void IncrementCheckboxEventCount()
    {
        checkboxEventCount++;
    }
}
