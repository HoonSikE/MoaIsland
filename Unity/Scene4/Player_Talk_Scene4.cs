using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Player_Talk_Scene4 : MonoBehaviour {
    // 게임 매니저
    public GameManager_Components GameManager;
    // 대화 매니저
    public TalkManager_Scene4 TalkManager;
    // 퀘스트 매니저
    public QuestManager_Scene4 QuestManager;
    // Fade
    public FadeManager_Components fade;

    // 선택지
    public bool SecondSelectStart = false;
    
    // 현재 퀘스트 진행 사항
    public Text QuestCurrentText;

    // 식별한 GameObject
    GameObject scanObject;

    public GameObject NextSelectButton;
    public GameObject SelectText1;
    public GameObject SelectText2;
    public bool Select1_1 = false;
    public bool Select1_2 = false;
    public bool Select1_3 = false;

    public bool Select2_1 = false;
    public bool Select2_2 = false;

    void OnTriggerEnter(Collider other){
        // ChatObject Tag라면
        if (other.tag == "ChatObect"){
            // scanObject로 인식
            scanObject = other.gameObject;
        }
        // Trigger된 상태가 다음 씬으로 넘어가는 포털이면
        if (other.tag == "NextMap") {
            QuestCurrentText.text = "완료";
            fade.FadeOut();
            // 다음 씬으로 이동
            Invoke("nextScene", 1.0f);
        }
    }

    void Update(){
        if(scanObject != null){
            // Chat 버튼(P)를 눌렀을 때
            if(Input.GetButtonDown("Chat")){
                // 다음으로 넘길 수 있는 상태라면
                if(TalkManager.nextChat){
                    if(QuestManager.Newspaper.activeSelf)
                    {
                        QuestManager.Newspaper.SetActive(false);
                    }

                    // 식별한 gameObject에 대한 대화 출력
                    PlayerTalk();
                }
            }
        }
    }

    void OnTriggerStay(Collider other){

    }

    void OnTriggerExit(Collider other){
        // scanObject 초기화
        scanObject = null;
    }
    // Button에 사용하기 위해서는 public으로 빼줘야한다.
    public void PlayerTalk(){
        if (TalkManager.nextChat)
        {
            if (QuestManager.SelectOne.activeSelf)
            {
                QuestManager.SelectOne.SetActive(false);
            }
            else if (QuestManager.SelectTwo.activeSelf)
            {
               QuestManager.SelectTwo.SetActive(false);
            }
        }
        if (QuestManager.questId == 0 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 1 && scanObject.gameObject.name == "NPC Box"){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 10 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 2){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 10 && QuestManager.questActionIndex == 1 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 10 && QuestManager.questActionIndex == 2 && TalkManager.talkIndex == 5){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 10 && QuestManager.questActionIndex == 3 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 3){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 3 && TalkManager.talkIndex == 2 && scanObject.gameObject.name == "NPC Box"){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 4 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
            if(Select2_1){
                QuestManager.questActionIndex++;
            }
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 5 && TalkManager.talkIndex == 1){
            QuestManager.startCount2();
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 6 && TalkManager.talkIndex == 1){
            QuestManager.startCount();
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 7 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
            if(Select2_1){
                QuestManager.questActionIndex++;
            }
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 8 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if (QuestManager.questId == 20 && QuestManager.questActionIndex == 9 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        } else if (QuestManager.questId == 30 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 2){
            TalkManager.TalkAction(scanObject);
        }

        // 다음으로 넘길 수 없는 상태로 설정
        TalkManager.nextChat = false;
        // 다음으로 넘길 수 있는 버튼 비활성화
        TalkManager.ButtonNextChat.SetActive(false);
        // 식별한 gameObject에 대한 대화 출력
        TalkManager.TalkAction(scanObject);
    }
    // 다음 씬 이동
    public void nextScene(){
        SceneManager.LoadScene(GameManager.stage + 1);
    }

    public void selectButton1_1(){
        if(Select1_1){
            Select1_1 = false;
            NextSelectButton.SetActive(false);
            TalkManager.nextChat = false;
        }else{
            Select1_1 = true;
            NextSelectButton.SetActive(true);
            TalkManager.nextChat = true;
            SelectText1.SetActive(false);
        }
        Select1_2 = false;
        Select1_3 = false;
        toggleSelectText1();
    }
    public void selectButton1_2(){
        if(Select1_2){
            Select1_2 = false;
            NextSelectButton.SetActive(false);
            TalkManager.nextChat = false;
        }else{
            Select1_2 = true;
            NextSelectButton.SetActive(true);
            TalkManager.nextChat = true;
            SelectText1.SetActive(false);
        }
        Select1_1 = false;
        Select1_3 = false;
        toggleSelectText1();
    }
    public void selectButton1_3(){
        if(Select1_3){
            Select1_3 = false;
            NextSelectButton.SetActive(false);
            TalkManager.nextChat = false;
        }else{
            Select1_3 = true;
            NextSelectButton.SetActive(true);
            TalkManager.nextChat = true;
            SelectText1.SetActive(false);
        }
        Select1_1 = false;
        Select1_2 = false;
        toggleSelectText1();
    }

    public void selectButton2_1(){
        if(Select2_1){
            Select2_1 = false;
            NextSelectButton.SetActive(false);
            TalkManager.nextChat = false;
        }else{
            Select2_1 = true;
            NextSelectButton.SetActive(true);
            TalkManager.nextChat = true;
            SelectText2.SetActive(false);
        }

        Select2_2 = false;
        toggleSelectText2();
    }

    public void selectButton2_2(){
        if(Select2_2){
            Select2_2 = false;
            NextSelectButton.SetActive(false);
            TalkManager.nextChat = false;
        }else{
            Select2_2 = true;
            NextSelectButton.SetActive(true);
            TalkManager.nextChat = true;
            SelectText2.SetActive(false);
        }
        Select2_1 = false;
        toggleSelectText2();
    }

    public void toggleSelectText1(){
        if(!Select1_1 && !Select1_2 && !Select1_3){
            SelectText1.SetActive(true);
        }
    }
    public void toggleSelectText2(){
        if(!Select2_1 && !Select2_2){
            SelectText2.SetActive(true);
        }
    }
}
