using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Talk_Scene6 : MonoBehaviour {
    // 게임 매니저
    public GameManager_Components GameManager;
    // 대화 매니저
    public TalkManager_Scene6 TalkManager;
    public QuestManager_Scene6 QuestManager;
    // Fade
    public FadeManager_Components fade;
    // 식별한 GameObject
    public GameObject scanObject;

    // 시작 스크립트
    void Awake(){
        PlayerTalk();
    }

    void Update(){
        GameManager.isAction = false;
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
        if (other.tag == "ChatObect"){
            // scanObject로 인식
            scanObject = other.gameObject;
        }
        // Trigger된 상태가 다음 씬으로 넘어가는 포털이면
        if (other.tag == "NextMap") {
            fade.FadeOut();
            // 다음 씬으로 이동
            Invoke("nextScene", 1.0f);
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
        if(QuestManager.questId == 0 && QuestManager.questActionIndex == 0 && TalkManager.talkIndex == 1){
            Invoke("PlayerTalk2", 2.0f);
        }else if(QuestManager.questId == 0 && QuestManager.questActionIndex == 1 && TalkManager.talkIndex == 1){
            TalkManager.TalkAction(scanObject);
        }else if(QuestManager.questId == 0 && QuestManager.questActionIndex == 2 && TalkManager.talkIndex == 4){
            Invoke("PlayerTalk2", 1.0f);
        }
        // 다음으로 넘길 수 없는 상태로 설정
        TalkManager.nextChat = false;
        // 다음으로 넘길 수 있는 버튼 비활성화
        TalkManager.ButtonNextChat.SetActive(false);
        // 식별한 gameObject에 대한 대화 출력
        TalkManager.TalkAction(scanObject);


    }
    public void PlayerTalk2(){
        TalkManager.TalkAction(scanObject);
    }
    // 다음 씬 이동
    public void nextScene(){
        SceneManager.LoadScene(GameManager.stage + 1);
    }
}
