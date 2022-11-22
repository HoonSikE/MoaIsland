using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownOption : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    private string[] gradeList = new string[6] {"1�г�", "2�г�", "3�г�", "4�г�", "5�г�", "6�г�"};

    private void Awake()
    {
        // ���� dropdown�� �ִ� ��� �ɼ��� ����
        dropdown.ClearOptions();

        // ���ο� �ɼ� ������ ���� OptionData ����
        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        // gradeList �迭�� �ִ� ��� ���ڿ� �����͸� �ҷ��ͼ� optionList�� ����
        foreach (string grade in gradeList)
        {
            optionList.Add(new TMP_Dropdown.OptionData(grade));
        }

        // ������ ������ optionList�� dropdown�� �ɼ� ���� �߰�
        dropdown.AddOptions(optionList);

        // ���� dropdown�� ���õ� �ɼ��� 0������ ����
        dropdown.value = 0;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
