using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DropdownOption : MonoBehaviour
{
    [SerializeField]
    private TMP_Dropdown dropdown;
    private string[] gradeList = new string[6] {"1학년", "2학년", "3학년", "4학년", "5학년", "6학년"};

    private void Awake()
    {
        // 현재 dropdown에 있는 모든 옵션을 제거
        dropdown.ClearOptions();

        // 새로운 옵션 설정을 위한 OptionData 생성
        List<TMP_Dropdown.OptionData> optionList = new List<TMP_Dropdown.OptionData>();

        // gradeList 배열에 있는 모든 문자열 데이터를 불러와서 optionList에 저장
        foreach (string grade in gradeList)
        {
            optionList.Add(new TMP_Dropdown.OptionData(grade));
        }

        // 위에서 생성한 optionList를 dropdown의 옵션 값에 추가
        dropdown.AddOptions(optionList);

        // 현재 dropdown에 선택된 옵션을 0번으로 설정
        dropdown.value = 0;
    }

    void Start()
    {
        
    }


    void Update()
    {
        
    }
}
