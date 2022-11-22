using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player_Talk_Scene2 : MonoBehaviour {
    // 게임 매니저
    public GameManager_Components GameManager;
    // 대화 매니저
    public TalkManager_Scene2 TalkManager;
    // 퀘스트 매니저
    public QuestManager_Scene2 QuestManager;
    // Fade
    public FadeManager_Components fade;
    
    // 식별한 GameObject
    public GameObject scanObject;

    // public Text Select1;
    // public Text Select2;

    // 현재 퀘스트 진행 사항
    public Text QuestCurrentText;

    
    public GameObject NextSelectButton;
    public GameObject SelectText;
    public bool Select1 = false;
    public bool Select2 = false;
    
    public bool chatObeject = true;
    public bool chatObejectExit = false;
    public bool baseChat = false;


    void Update(){
        if(scanObject != null){
            // Chat 버튼(P)를 눌렀을 때
            if(Input.GetButtonDown("Chat")){
                // 다음으로 넘길 수 있는 상태라면
                if(TalkManager.nextChat){
                    // 식별한 gameObject에 대한 대화 출력
                    PlayerTalk();
                }
            }
        }
    }
    void OnTriggerEnter(Collider other){
        // ChatObject Tag라면
        if (other.tag == "ChatObect" && chatObeject){
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

    void OnTriggerStay(Collider other){
        // ChatObject Tag라면
        if (other.tag == "ChatObect" && chatObeject){
            // scanObject로 인식
            scanObject = other.gameObject;
        }
    }

    void OnTriggerExit(Collider other){
        if(!chatObejectExit){
            scanObject = null;
        }    
    }

    // Button에 사용하기 위해서는 public으로 빼줘야한다.
    public void PlayerTalk(){
        if(QuestManager.questId == 0 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 1 && scanObject.gameObject.name == "NPC Box"){
            TalkManager.TalkAction(scanObject);
        }else if(QuestManager.questId == 10 && QuestManager.questActionIndex == 2 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if(QuestManager.questId == 10 && QuestManager.questActionIndex == 3 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if(QuestManager.questId == 20 && QuestManager.questActionIndex == 2 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }
        if(QuestManager.questId == 10 && QuestManager.questActionIndex == 1 && TalkManager.talkIndex == 3){
            QuestManager.questObject[2].SetActive(false);
            TalkManager.TalkAction(scanObject);
            if(Select2){
                QuestManager.questActionIndex++;
            }
        }

        chatObeject = false;
        chatObejectExit = true;
        // 다음으로 넘길 수 없는 상태로 설정
        TalkManager.nextChat = false;
        // 다음으로 넘길 수 있는 버튼 비활성화
        TalkManager.ButtonNextChat.SetActive(false);
        // 식별한 gameObject에 대한 대화 출력
        TalkManager.TalkAction(scanObject);
    }
    public void PlayerTalk2(){
        if(TalkManager.nextChat){
            chatObeject = false;
            chatObejectExit = true;
            // 다음으로 넘길 수 없는 상태로 설정
            TalkManager.nextChat = false;
            // 다음으로 넘길 수 있는 버튼 비활성화
            TalkManager.ButtonNextChat.SetActive(false);
            // 식별한 gameObject에 대한 대화 출력
            TalkManager.TalkAction(scanObject);
        }
    }
    // 다음 씬 이동
    public void nextScene(){
        SceneManager.LoadScene(GameManager.stage + 1);
    }

    public void selectButton1(){
        if(Select1){
            Select1 = false;
            TalkManager.nextChat = false;
            NextSelectButton.SetActive(false);
        }else{
            Select1 = true;
            TalkManager.nextChat = true;
            NextSelectButton.SetActive(true);
            SelectText.SetActive(false);
        }

        Select2 = false;
        toggleSelectText();
    }

    public void selectButton2(){
        if(Select2){
            Select2 = false;
            TalkManager.nextChat = false;
            NextSelectButton.SetActive(false);
        }else{
            Select2 = true;
            TalkManager.nextChat = true;
            NextSelectButton.SetActive(true);
            SelectText.SetActive(false);
        }
        Select1 = false;

        toggleSelectText();
    }
    public void toggleSelectText(){
        if(!Select1 && !Select2){
            SelectText.SetActive(true);
        }
    }
/*    public void ChangeTextColor1(){
        Select1.text = "<color=red>" + Select1.text + "</color>";
    }

    public void ChangeTextColor2(){
        Select2.text = "<color=red>" + Select2.text + "</color>";
    }
*/
}
