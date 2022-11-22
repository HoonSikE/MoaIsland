using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
// 퀘스트 매니저
public class QuestManager_Scene6 : MonoBehaviour {
    // 게임 매니저
    public GameManager_Components GameManager;

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

    // Fade
    public FadeManager_Components fade;

    public GameObject Stamp;

    void Awake(){
        Stamp.SetActive(true);
        questList = new Dictionary<int, QuestData_Components>();
        GenerateData();
        // 시작하자마자 맵 전환
        //Invoke("nextScene6_1_1", 3.0f);
    }
    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData(){
        questList.Add(0, new QuestData_Components(
            "",
             new int[] {0, 0, 0}
        ));
        questList.Add(10, new QuestData_Components(
            "",
             new int[] {0}
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
                switch(questActionIndex){
                    case 1:
                        /* 유령 뿅!*/
                        questObject[2].SetActive(true);
                        questObject[3].SetActive(true);
                        break;
                    case 2:
                        break;
                    case 3:
                        fade.Fade();
                        Invoke("nextScene6_2", 1.0f);
                        break;
                }
                break;
            case 10:
                fade.FadeOut();
                // 다음 씬으로 이동
                Invoke("nextScene", 1.0f);
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
    public void nextScene6_1_1(){
        fade.Fade();
        Invoke("nextScene6_1_2", 1.0f);
    }
    public void nextScene6_1_2(){
        questObject[0].SetActive(false);
        questObject[1].SetActive(true);
        questObject[4].SetActive(false);
        questObject[5].SetActive(true);
    }
    public void nextScene6_2(){
        questObject[1].SetActive(false);
        questObject[6].SetActive(true);
        questObject[5].transform.localEulerAngles = new Vector3(0, 180, 0);
    }
    // 다음 씬 이동
    public void nextScene(){
        SceneManager.LoadScene(GameManager.stage + 1);
    }
}
