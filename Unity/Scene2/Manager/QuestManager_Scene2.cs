using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 퀘스트 매니저
public class QuestManager_Scene2 : MonoBehaviour {
    // 플레이어 정보
    public Player_Item_Scene2 player;
    public Player_Talk_Scene2 playerTalk;
    // 네비게이션
    public Navigation_Components Navigation;
    // 아이템 매니저
    public ItemManager_Scene2 ItemManager;

    public GameObject npcChat;
    public GameObject boardChat;

    // 퀘스트 ID (초기값: 0)
    public int questId;
    // 퀘스트 내의 NPC 순서 (초기값: 0)
    public int questActionIndex;

    // 대화창
    // public GameObject chatImg;

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

    public GameObject Stamp;


    void Awake(){
        Stamp.SetActive(true);
        npcChat.SetActive(true);
        boardChat.SetActive(false);
        questList = new Dictionary<int, QuestData_Components>();
        GenerateData();
    }

    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData(){
        questList.Add(0, new QuestData_Components(
            "게시판 확인하기",
             new int[] {1000, 1000}
        ));
        questList.Add(10, new QuestData_Components(
            "게시판 확인하기",
             new int[] {2000, 1000, 1000, 1000}
        ));
        questList.Add(20, new QuestData_Components(
            "별 모으기",
             new int[] {1000, 1000, 1000}
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
            case 0:
                if(questActionIndex == (questList[questId].npcId.Length)){
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    Navigation.nextIndex = 1;
                    showQuestWindow();
                    boardChat.SetActive(true);
                    npcChat.SetActive(false);
                    playerTalk.chatObeject = true;
                    playerTalk.scanObject = null;
                    playerTalk.chatObejectExit = false;
                }
                break;
            case 10:
                switch(questActionIndex){
                    case 1:
                        Navigation.nextIndex = 0;
                        QuestCurrentText.text = "완료";
                        boardChat.SetActive(false);
                        npcChat.SetActive(true);
                        playerTalk.chatObeject = true;
                        playerTalk.scanObject = null;
                        playerTalk.chatObejectExit = false;
                        break;
                    case 2:
                        QuestWindow.SetActive(false);
                        break;
                    case 3:
                        questActionIndex++;
                        break;
                    case 4:
                        break;
                }
                break;
            case 20:
                npcChat.SetActive(false);
                if(player.itemCount == ItemManager.TotalNumTextCount)
                {
                    npcChat.SetActive(true);
                }
                if (questActionIndex == 1) {
                    questObject[0].SetActive(true);
                    // Navigation.Navi.SetActive(false);
                    Navigation.nextIndex = 4;
                    QuestCurrentText.text = 0.ToString();
                    QuestResultText.text = " / " + ItemManager.TotalNumTextCount;
                    showQuestWindow();
                    playerTalk.chatObeject = true;
                    playerTalk.scanObject = null;
                    playerTalk.chatObejectExit = false;
                }
                // 별을 덜 모음
                else if(questActionIndex == 2){
                    if(player.itemCount < ItemManager.TotalNumTextCount){
                        questActionIndex--;
                    }
                    else if(player.itemCount == ItemManager.TotalNumTextCount){
                        QuestWindow.SetActive(false);
                    }
                    playerTalk.chatObeject = true;
                    playerTalk.scanObject = null;
                    playerTalk.chatObejectExit = false;
                }
                break;
            // 마지막 퀘스트
            case 30:
                if (questActionIndex == (questList[questId].npcId.Length)){
                    questObject[3].SetActive(true);
                    Navigation.nextIndex = 3;
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    showQuestWindow();
                    questActionIndex--;
                    playerTalk.chatObeject = true;
                    playerTalk.scanObject = null;
                    playerTalk.chatObejectExit = false;
                }
                npcChat.SetActive(false);
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
