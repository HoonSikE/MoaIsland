using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 퀘스트 매니저
public class QuestManager_Scene1 : MonoBehaviour {
    public GameObject npcChat;
    // 퀘스트 ID (초기값: 0)
    public int questId;
    // 퀘스트 내의 NPC 순서 (초기값: 0)
    public int questActionIndex;
    // 퀘스트 창
    public GameObject QuestWindow;
    // 퀘스트 이름
    public Text QuestTitle;

    // 현재 퀘스트 진행 사항
    public Text QuestCurrentText;
    // 퀘스트 완료 조건
    public Text QuestResultText;

    // 퀘스트 데이터를 저장하는 Dictionary
    Dictionary<int, QuestData_Components> questList;

    // 퀘스트 오브젝트를 저장할 변수
    public GameObject[] questObject;

    // 네비게이션
    public Navigation_Components Navigation;

    void Awake(){
        npcChat.SetActive(false);
        questList = new Dictionary<int, QuestData_Components>();
        GenerateData();
    }
    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData(){
        questList.Add(10, new QuestData_Components(
            "NPC를 찾아가자!",
             new int[] {0}
        ));
        questList.Add(20, new QuestData_Components(
             "NPC를 찾아가자!",
             new int[] {1000, 1000}
        ));
        questList.Add(30, new QuestData_Components(
            "다음 섬으로 이동",
             new int[] {1000}
        ));
    }
    // QuestIndex 값 반환
    public int GetQuestTalkIndex(int id){
        return questId + questActionIndex;
    }
    // 퀘스트 진행 함수
    public void CheckQuest(int id){
        // 키에 값이 들어있다면
        if(questList.ContainsKey(questId)){
            // 퀘스트 대화순서를 1 올린다. (다음 NPC로)
            if(id == questList[questId].npcId[questActionIndex])
                questActionIndex++;

            ControlObject();

            // 퀘스트 마지막 대화라면 다음 퀘스트
            if(questActionIndex == questList[questId].npcId.Length)
                NextQuest();
        }
    }
    // 다음 퀘스트
    public void NextQuest(){
        questId += 10;
        questActionIndex = 0;
    }
    // 퀘스트 오브젝트를 관리할 함수
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    public void ControlObject(){
        switch(questId){
            case 10:
                npcChat.SetActive(true);
                // id==0인 채팅이 끝나면 퀘스트 창 생성
                if(questActionIndex == (questList[questId].npcId.Length)){
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    showQuestWindow();
                }
                break;
            case 20:
                if(questActionIndex == (questList[questId].npcId.Length)){
                    QuestCurrentText.text = "완료";
                    showQuestWindow();
                   // 3초 뒤 창 사라짐
                    Invoke("HideQuestWindow", 1.0f);
                }
                break;
            // 튜토리얼이 끝났으니 다음 섬으로 이동하자.
            case 30:
                npcChat.SetActive(false);
                if (questActionIndex == (questList[questId].npcId.Length)){
                    questObject[1].SetActive(true);
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    showQuestWindow();
                    Navigation.nextIndex = 1;
                    questActionIndex--;
                }
                break;
        }
    }
    public void showQuestWindow(){
        // 우측에 퀘스트 창을 띄운다.
        QuestWindow.SetActive(true);
        // 우측에 퀘스트 이름을 설정한다.
        QuestTitle.text = questList[questId].questName;
    }
    public void HideQuestWindow(){
        QuestWindow.SetActive(false);
    }
}
