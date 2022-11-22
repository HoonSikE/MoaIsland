using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
// 퀘스트 매니저
public class QuestManager_Scene4 : MonoBehaviour
{
    public GameObject npcChat1;
    public GameObject npcChat2;
    public GameObject npcChat3;
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

    // 선택지 버튼들
    public GameObject SelectOne;
    public GameObject SelectTwo;
    public GameObject Newspaper;
    public GameObject Letter;
    public GameObject FirstText;
    public GameObject SecondText;
    public Button btn;
    private float size = 1f;  // 원하는 사이즈
    private float speed = 2f;    // 작아질 때의 속도
    private float downsize = 0.0001f;
    private float time;

    public Player_Talk_Scene4 PlayerTalk;
    public TextMeshProUGUI Money;

    public Navigation_Components Navigation;

    public GameObject Stamp;

    void Awake()
    {
        Stamp.SetActive(true);
        npcChat1.SetActive(true);
        npcChat2.SetActive(false);
        npcChat3.SetActive(false);
        questList = new Dictionary<int, QuestData_Components>();
        GenerateData();
    }

    private void Update()
    {
    }
    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData()
    {
        questList.Add(0, new QuestData_Components(
            "",
             new int[] { 1000 }
        ));
        questList.Add(10, new QuestData_Components(
            "",
             new int[] { 1000, 1000, 1000, 1000 }
        ));
        questList.Add(20, new QuestData_Components(
            "직접 투자를 해보자!!",
             new int[] {1000, 2000, 3000, 1000, 1000
                        , 1000, 1000, 1000, 1000, 1000}
        ));
        questList.Add(30, new QuestData_Components(
            "다음 섬으로 이동",
             new int[] { 1000, 1000 }
        ));
    }
    // QuestIndex 값 반환
    public int GetQuestTalkIndex(int id)
    {
        if(questId + questActionIndex == 13)
        {
            FirstText.SetActive(true);
            SecondText.SetActive(false);
            //StartCoroutine(Up(Letter));
            Letter.SetActive(true);
        }
        else if(questId + questActionIndex == 20)
        {
            //StartCoroutine(Down(Letter));
            Letter.SetActive(false);

        }

        else if (questId + questActionIndex == 27)
        {
            FirstText.SetActive(false);
            SecondText.SetActive(true);
            //StartCoroutine(Up(Letter));
            Letter.SetActive(true);
        }
        return questId + questActionIndex;

    }
    // 퀘스트 진행 함수
    public void CheckQuest(int id)
    {
        // 키에 값이 들어있다면
        if (questList.ContainsKey(questId))
        {
            // 퀘스트 대화순서를 1 올린다. (다음 NPC로)
            if (id == questList[questId].npcId[questActionIndex])
                questActionIndex++;
                
            ControlObject();

            // 퀘스트 마지막 대화라면 다음 퀘스트
            if (questActionIndex == questList[questId].npcId.Length)
                NextQuest();
        }
    }
    // 다음 퀘스트
    public void NextQuest()
    {
        questId += 10;
        questActionIndex = 0;
    }
    // 퀘스트 오브젝트를 관리할 함수
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    public void ControlObject()
    {
        switch (questId)
        {
            case 0:
                break;
            case 10:
                switch (questActionIndex)
                {
                    case 1:
                        break;
                    case 2:
                        /* 여기에 선택 UI */
                        break;
                    case 3:
                        break;
                    case 4:
                        /* 여기에 주식설명 UI */
                        break;
                }
                break;
            case 20:
                switch (questActionIndex)
                {
                    // 주식 퀘스트 시작
                    case 1:
                        QuestCurrentText.text = "진행 중";
                        QuestResultText.text = " / 완료";
                        Navigation.nextIndex = 1;
                        npcChat1.SetActive(false);
                        npcChat2.SetActive(true);
                        npcChat3.SetActive(false);
                        showQuestWindow();
                        break;
                    case 2:
                        npcChat1.SetActive(false);
                        npcChat2.SetActive(false);
                        npcChat3.SetActive(true);
                        Navigation.nextIndex = 2;
                        break;
                    case 3:
                        npcChat1.SetActive(true);
                        npcChat2.SetActive(false);
                        npcChat3.SetActive(false);
                        Navigation.nextIndex = 0;
                        break;
                    case 4:
                        break;
                    case 5:
                        /* 기업 선택 UI */
                        /* 나쁜 기업 선택 시 1개 건너 띔 */
                        break;
                    case 6:
                        /* 좋은 결과 UI */
                        Newspaper.SetActive(false);
                        questActionIndex ++;
                        break;
                    case 7:
                        /* 나쁜 결과 UI */
                        Newspaper.SetActive(false);
                        break;
                    case 8:
                        /* 주식 주의 사항 UI */
                        Letter.SetActive(false);
                        /* 나쁜 기업 선택 시 1개 건너 띔 */
                        break;
                    case 9:
                        /* 좋은 기업 결과 */
                        // 아마 주식NPC 감정표현 칭찬
                        questActionIndex ++;
                        break;
                    case 10:
                        /* 나쁜 기업 결과 */
                        // 아마 주식NPC 감정표현 놀림
                        break;
                }
                break;
            // 모든 미션이 끝났으니 다음 섬으로 이동하자.
            case 30:
                if (questActionIndex == (questList[questId].npcId.Length))
                {
                    npcChat1.SetActive(false);
                    questObject[1].SetActive(true);
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    Navigation.nextIndex = 3;
                    showQuestWindow();
                    questActionIndex--;
                }
                break;
        }
    }
    public void showQuestWindow()
    {
        // 우측에 퀘스트 창을 띄운다.
        QuestWindow.SetActive(true);
        // 우측에 퀘스트 이름을 설정한다.
        QuestTitle.text = questList[questId].questName;
    }
    public void HideQuestWindow()
    {
        QuestWindow.SetActive(false);
    }
    public void QuestComplete()
    {
        QuestCurrentText.text = "완료";
    }

    IEnumerator Up(GameObject letter)
    {
        while (letter.transform.localScale.x < size)
        {
            //stamp1.transform.localScale = stamp1.transform.localScale * (1f - time * speed);
            letter.transform.localScale = new Vector3(
                letter.transform.localScale.x + 1f * speed * time,
                letter.transform.localScale.y + 1f * speed * time,
                0
            );
            time += Time.deltaTime;

            if (letter.transform.localScale.x >= size)
            {
                time = 0;
                letter.transform.localScale = new Vector3(size, size, 0);
                break;
            }
            yield return null;
        }
    }

    IEnumerator Down(GameObject letter)
    {
        while (letter.transform.localScale.x > downsize)
        {
            //stamp1.transform.localScale = stamp1.transform.localScale * (1f - time * speed);
            letter.transform.localScale = new Vector3(
                letter.transform.localScale.x - 1f * speed * time,
                letter.transform.localScale.y - 1f * speed * time,
                0
            );
            time += Time.deltaTime;

            if (letter.transform.localScale.x <= downsize)
            {
                time = 0;
                letter.transform.localScale = new Vector3(downsize, downsize, 0);
                break;
            }
            yield return null;
        }
    }
    public void onButtonClick()
    {
        StartCoroutine(Down(Letter));

    }

    public void startCount(){
        StartCoroutine(Count(9000, 12000));
    }

    //target->줄어든이후돈, current->시작돈
    IEnumerator Count(float target, float current)
    {
        float duration = 2f; // 카운팅에 걸리는 시간 설정. 
        float offset = (current - target) / duration; // 

        while (current > target)
        {
            current -= offset * Time.deltaTime;
            Debug.Log(current);
            Money.text = ((int)current).ToString();
            yield return null;
        }
        current = target;
        //pointText->왼쪽위 돈 text mesh
        Money.text = ((int)current).ToString();
    }

    public void startCount2(){
        StartCoroutine(Count2(15000, 12000));
    }

    // target-> 늘어난 후 , current -> 시작
    IEnumerator Count2(float target, float current)
    {
        float duration = 0.6f; // 카운팅에 걸리는 시간 설정. 
        float offset = (target - current) / duration;
        while (current < target)
        {
            current += offset * Time.deltaTime;
            // Debug.Log(current);
            Money.text = ((int)current).ToString();
            yield return null;
        }
        current = target;
        //pointText->왼쪽위 돈 text mesh
        Money.text = ((int)current).ToString();
    }
}
