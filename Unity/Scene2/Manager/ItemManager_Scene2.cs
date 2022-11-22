using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 아이템 매니저
public class ItemManager_Scene2 : MonoBehaviour {
    // 전체 아이템 개수 (초기값 : 10 (소비섬 기준))
    public int TotalNumTextCount;
    // 현재 금액
    public TextMeshProUGUI CurrentMoneyText;
    // 현재 획득 아이템 개수 Text
    public Text QuestCurrentText;
    // 아이템 전체 개수 Text
    public Text QuestResultText;
    // 퀘스트 매니저
    public QuestManager_Scene2 QuestManager;

    // // 시작하면 전체 아이템 값을 초기화 해준다.
    // void Awake(){
    //     QuestResultText.text = "/ " + TotalNumTextCount;
    // }
    
    public void GetItem(int count){
        QuestCurrentText.text = count.ToString();
        //CurrentMoneyText.text = (count*1000).ToString();
        StartCoroutine( Count2(count*1000f, (count-1)*1000f));

        // Item을 다 모으면 quest Index 1 증가
        if(count == TotalNumTextCount){
            QuestManager.questActionIndex++;
        }
    }

    // target-> 늘어난 후 , current -> 시작
    IEnumerator Count2(float target, float current)
    {

        float duration = 0.6f; // 카운팅에 걸리는 시간 설정. 
        float offset = (target - current) / duration;

        while (current < target)
        {
            current += offset * Time.deltaTime;
            Debug.Log(current);
            CurrentMoneyText.text = ((int)current).ToString();
            yield return null;
        }

        current = target;
        //pointText->왼쪽위 돈 text mesh
        CurrentMoneyText.text = ((int)current).ToString();
    }
}
