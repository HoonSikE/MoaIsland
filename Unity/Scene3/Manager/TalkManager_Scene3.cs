using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 대화 매니저
public class TalkManager_Scene3 : MonoBehaviour {
    // 게임 매니저
    public GameManager_Components GameManager;
    // 대화 내용 데이터
    public TalkDictionary_Scene3 TalkDictionary;
    // 퀘스트 매니저
    public QuestManager_Scene3 QuestManager;
    // 대화창 전체
    public GameObject talkPanel;
    // 다음 대화 버튼
    public GameObject ButtonNextChat;
    // 유저 이름
    public Text userText;
    // 대화 내용
    public Text talkText;
    // N번째 대화 (초기값: 0)
    public int talkIndex;
    // 다음으로 넘어갈 수 있는지? (초기값: ture)
    // ex) 타닥타닥 글씨가 다 나오면 다음으로 넘어갈 수 있다.
    public bool nextChat;

    public bool isPopupOpen;

    public PopupManager_Scene3 popupManager;

    // 플레이어 이름 관리 오브젝트
    PlayerNameManager_Components playerNameManager;
    // 플레이어 이름
    string playerName = "";

    public TextMeshProUGUI Money;

    public AudioClip MoneySound;
    AudioSource audioSource;

    [SerializeField] public Text accountName;

    void Awake()
    {
        // DontDestroyOnLoad로 넘어온 PlayerNameManager 오브젝트를 찾음
         playerNameManager = GameObject.Find("PlayerNameManager").GetComponent<PlayerNameManager_Components>();
        // playerName 설정
         playerName = playerNameManager.GetPlayerName();
        this.audioSource = GetComponent<AudioSource>();
        accountName.text = playerName;
    }

    public void TalkAction(GameObject scanObj){
        // ObjectData 컴포넌트를 받아온다.
        // ObjectData에는 id(ind), isNpc(bool)가 들어있다.
        ObjectData_Components objData = scanObj.GetComponent<ObjectData_Components>();
        // 초기값을 비워준다. (없어도 됨)
        talkText.text = "";

        // id와 isNpc에 맞는 스크립트를 불러온다.
        Talk(objData.id, objData.isNpc);
    }

    // 스크립트 내용을 불러온다.
    void Talk(int id, bool isNpc) {
        // 이동불가 상태로 변경 (Player.cs에서 적용)
        GameManager.isAction = false;

        // 퀘스트 매니저를 통해 퀘스트 인덱스를 받아온다.
        int questTalkIndex = QuestManager.GetQuestTalkIndex(id);
        // TalkDictionary_Test에서 스크립트를 불러온다.
        // 씬마다 내용이 다르므로 분리했습니다.
        string talkData = TalkDictionary.GetTalk(questTalkIndex + id, talkIndex);

        // talkData가 비었다면 마지막 내용
        if(talkData == null){
            // 채팅창 가리기
            talkPanel.SetActive(false);
            // 이동가능 상태로 변경 (Player.cs에서 적용)
            GameManager.isAction = true;
            // talkIndex 초기화
            talkIndex = 0;
            nextChat = true;
            // 대화가 끝나면다음 NPC로 넘어감
            QuestManager.CheckQuest(id);

            return;
        }
        // 스크립트를 불러왔으니 대화창을 출력한다.
        // 이전 값이 보일 수도 있으므로 Talk를 먼저 호출해준다.
        talkPanel.SetActive(true);

        // talkData는 "유저이름:내용"의 형식으로 되어있다.
        string[] talkDataArray = talkData.Split(":");


        // ##### -> playerName으로 변경
        if (talkDataArray[0].Contains("#####"))
            talkDataArray[0] = talkDataArray[0].Replace("#####", playerName);

        if (talkDataArray[1].Contains("#####"))
            talkDataArray[1] = talkDataArray[1].Replace("#####", playerName);


        // 유저이름 Text 적용
        userText.text = talkDataArray[0];
        // 내용 Text 적용 -> 한글자씩 타닥타닥 나옴.
        StartCoroutine(Typing(talkDataArray[1]));



        Debug.Log(questTalkIndex + id + " " + talkIndex);
        if (questTalkIndex + id == 2010 && talkIndex == 6)
        {
            talkPanel.SetActive(false);
            isPopupOpen = true;
            popupManager.changeMainToSign();

        }else if(questTalkIndex + id == 1020 && talkIndex == 1)
        {
            audioSource.clip = MoneySound;
            audioSource.Play();
            StartCoroutine(Count(0, 10000));
            talkPanel.SetActive(false);
            isPopupOpen = true;
            popupManager.depositPopup();
        }else if(questTalkIndex + id == 1020 && talkIndex == 6)
        {
            talkPanel.SetActive(false);
            isPopupOpen = true;
            popupManager.interestPopup();
        }else if (questTalkIndex + id == 1020 && talkIndex == 12)
        {
            audioSource.clip = MoneySound;
            audioSource.Play();
            StartCoroutine(Count2(12000, 0));
            talkPanel.SetActive(false);
            isPopupOpen = true;
            popupManager.withdrawalPopup();
        }else if (questTalkIndex + id == 1020 && talkIndex == 14)
        {
            talkPanel.SetActive(false);
            isPopupOpen = true;
            popupManager.letterPopup();
        }

        // 다음 Index로 변경
        // 값은 TalkManager에 저장하되, Player.cs에서 호출
        talkIndex++;
    }
    // 한글자씩 타닥타닥 나오는 함수
    IEnumerator Typing(string text) {
        foreach (char letter in text.ToCharArray()) {
            talkText.text += letter;
            yield return new WaitForSeconds(0.01f);
        }
        // 모든 문자가 출력되면 다음으로 넘어갈 수 있음.
        nextChat = true;
        // 다음으로 넘어가는 버튼 출력
        ButtonNextChat.SetActive(true);
    }
    
    // target->줄어든이후돈, current->시작돈
    IEnumerator Count(float target, float current)
    {

        float duration = 0.6f; // 카운팅에 걸리는 시간 설정. 
        float offset = (current - target) / duration; 

        while (current > target)
        {
            current -= offset * Time.deltaTime;
            // Debug.Log(current);
            Money.text = ((int)current).ToString();
            yield return null;
        }

        current = target;
        //pointText->왼쪽위 돈 text mesh
        Money.text = ((int)current).ToString();
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
