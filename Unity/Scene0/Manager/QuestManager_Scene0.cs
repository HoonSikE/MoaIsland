using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
// 퀘스트 매니저
public class QuestManager_Scene0 : MonoBehaviour {
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


    // 앤드류 오브젝트
    public GameObject andrew;
    // 여우 오브젝트
    public GameObject fox;
    // 폭발 효과 오브젝트
    public GameObject explosion;

    // 캐릭터 감소되는 크기
    Vector3 scaleChange = new Vector3(-0.07f, -0.07f, -0.07f);
    // 캐릭터 최소 크기
    Vector3 scaleMin = new Vector3(0.1f, 0.1f, 0.1f);
    // 캐릭터 최대 크기
    Vector3 scaleMax = new Vector3(0.8f, 0.8f, 0.8f);

    bool isShrink = false;
    bool isGrow = false;

    void Awake(){
        questList = new Dictionary<int, QuestData_Components>();
        GenerateData();
    }

    void Update()
    {
        if (isShrink)
            Shrink();
        if (isGrow)
            Grow();
    }

    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData(){
        questList.Add(0, new QuestData_Components(
            "",
             new int[] {0, 0}
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
                if (questActionIndex == 1)
                {
                    fade.Fade();
                    Invoke("nextScene0", 1.0f);
                }
                else if (questActionIndex == 2)
                {
                    Change();
                    Invoke("Fade", 1.0f);
                    // 다음 씬으로 이동
                    Invoke("nextScene", 2.0f);
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

    public void Fade()
    {
        fade.FadeOut();
    }

    public void HideQuestWindow(){
        QuestWindow.SetActive(false);
    }
    public void nextScene0(){
        questObject[0].SetActive(false);
        questObject[1].SetActive(true);

        andrew.transform.rotation = Quaternion.identity;
    }
    // 다음 씬 이동
    public void nextScene(){
        SceneManager.LoadScene(GameManager.stage + 1);
    }

    public void Change()
    {
        isShrink = true;
        
        explosion.SetActive(true); // 펑 효과 나타남
        explosion.GetComponent<ParticleSystem>().Play(); // 효과 플레이
    }

    public void Shrink()
    {

        if (andrew.transform.localScale.x > scaleMin.x)
        {
            andrew.transform.localScale += scaleChange;
        }
        else
        {
            isShrink = false;
            andrew.SetActive(false);

            isGrow = true;
            fox.SetActive(true);
        }
    }

    void Grow()
    {

        if (fox.transform.localScale.x < scaleMax.x)
        {
            fox.transform.localScale -= scaleChange;
        }
        else
        {
            isGrow = false;
        }

    }
}
