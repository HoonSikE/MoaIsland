using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 아이템 매니저
public class ItemManager_Sample : MonoBehaviour {
    // 전체 아이템 개수 (초기값 : 10 (소비섬 기준))
    public int TotalNumTextCount;
    // 현재 획득 아이템 개수 Text
    public Text QuestCurrentText;
    // 아이템 전체 개수 Text
    public Text QuestResultText;
    // 퀘스트 매니저
    public QuestManager_Sample QuestManager;

    // // 시작하면 전체 아이템 값을 초기화 해준다.
    // void Awake(){
    //     QuestResultText.text = "/ " + TotalNumTextCount;
    // }

    // 현재 아이템 개수를 Text에 적용한다.
    // Item을 먹을때 마다 적용해주려고 따로 있음.
    public void GetItem(int count){
        QuestCurrentText.text = count.ToString();

        // Item을 다 모으면 quest Index 1 증가
        if(count == TotalNumTextCount){
            QuestManager.questActionIndex++;
        }
    }
}
