using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// 퀘스트 매니저
public class QuestManager_Scene5 : MonoBehaviour {
    public BridgeFO fo;
    public Woong wo;
    public GameObject bridge;
    public GameObject birdgeBlock;
    public ParticleSystem Eff_Title_Opening;
    public GameObject npcMark1;
    public GameObject npcMark2;
    public GameObject coinUp;
    public GameObject[] buildNPC;
    public GameObject[] buildNPCDIS;
    public GameObject Start;
    public Button closebutton;

    public Navigation_Components nc;
    public AudioSource moneydown;
    public AudioSource coinSound;
    public AudioSource background;
    public Button btn;
    private float size = 1f;  // 원하는 사이즈
    private float speed = 2f;    // 작아질 때의 속도
    private float downsize = 0.0001f;
    private float time;
    public GameObject letter;
    public GameObject Arrow;
    public TextMeshProUGUI Money;
    public int point = 0;
    public float target;
    public float current;

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

    void Awake(){
        letter.SetActive(false);
        background.Play();
        buildNPC[0].SetActive(false);
        buildNPC[1].SetActive(false);
        questList = new Dictionary<int, QuestData_Components>();
        bridge.SetActive(false);
        Eff_Title_Opening.Pause();
        coinUp.SetActive(false);
        npcMark1.SetActive(true);
        npcMark2.SetActive(false);
        fo = FindObjectOfType<BridgeFO>();
        wo = FindObjectOfType<Woong>();
        nc = FindObjectOfType<Navigation_Components>();
        GenerateData();
        GameObject canvas = GameObject.Find("Canvas");
        if (canvas == null)
        {
            return;
        }
        Transform tf = canvas.transform;
        Arrow = tf.Find("Arrow").gameObject;
        if (Arrow == null)
        {
            return;
        }
        Arrow.SetActive(false);
        target = 10000f;
        current = 15000f;
        Money.text = "15000";
        moneydown = GetComponent<AudioSource>();
        StartCoroutine(Count(target, current));
    }

    // 퀘스트 Data
    // 무조건 TalkDictionary랑 같이 작성할 것!!!!
    void GenerateData(){
        questList.Add(0, new QuestData_Components(
            "너굴이와 대화",
             new int[] {100, 1000, 1000,1000}
        ));
        questList.Add(10, new QuestData_Components(
            "용용이에게 돌아가자!",
             new int[] {2000}
        ));
        questList.Add(20, new QuestData_Components(
            "세금으로 다리를 만들자!",
             new int[] { 1000, 1000, 1000 }
        ));
        questList.Add(30, new QuestData_Components(
            "다음 섬으로 이동",
             new int[] { 1000 }
        ));
    }
    public void CoinUP()
    {
        coinUp.SetActive(true);
        /*while (coinUp.transform.position.y<5)
        {
            coinUp.transform.Translate(Vector3.up * 0.1f * Time.deltaTime);
        }*/
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
                Debug.Log(questActionIndex);
                moneydown.Stop();
                if (questActionIndex == 2)
                {
                    letter.SetActive(true); 
                }
                
                if (questActionIndex == 3)
                {

                }
                // id==1000인 채팅이 끝나면 퀘스트 창 생성
                if (questActionIndex == (questList[questId].npcId.Length)){
                    npcMark1.SetActive(false);
                    npcMark2.SetActive(true);
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    showQuestWindow();
                    nc.nextIndex = 1;
                    Start.SetActive(false);
                }
                
                break;
            case 10:
                // 미납자를 찾아가면 완료
                if(questActionIndex == 1)
                {
                    QuestCurrentText.text = "완료";
                    QuestTitle.text = questList[questId].questName;
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    npcMark2.SetActive(false);
                    npcMark1.SetActive(true);
                    CoinUP();
                    coinSound.loop = false;
                    coinSound.Play();
                    Invoke("dis", 1f);
                    nc.nextIndex = 2;
                }
                
                // 세금으로 다리 건설하기 퀘스트 창으로 변경
                break;
            // 다리 건설이 끝났으니 다음 섬으로 이동하자.
            case 20:
                if (questActionIndex == 1)
                {
                    QuestTitle.text = questList[questId].questName;
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    buildNPC[0].SetActive(true);
                    buildNPC[1].SetActive(true);
                    buildNPCDIS[0].SetActive(false);
                    buildNPCDIS[1].SetActive(false);

                    Eff_Title_Opening.Play();
                    background.volume = 0.5f;
                    wo.go();

                    // QuestCurrentText.text = "진행 중";
                    //QuestResultText.text = " / 완료";

                    /* 여기에 다리건설 애니메이션 넣으면 될 듯 */
                    //Invoke("MakeBridge", 3.0f);
                    // 채팅이 끝나면 다리 건설
                }
                else if (questActionIndex == 2)
                {
                    background.volume = 1;
                    wo.stop();
                    background.Play();
                    QuestTitle.text = questList[questId].questName;
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    fo.Fade();
                    Invoke("build", 1f);
                }
                else if (questActionIndex == 3)
                {
                    
                    QuestCurrentText.text = "완료";
                }
                break;
           case 30:
                if(questActionIndex == (questList[questId].npcId.Length)){
                    nc.nextIndex = 3;
                    npcMark1.SetActive(false);
                    questObject[1].SetActive(true);
                    QuestCurrentText.text = "진행 중";
                    QuestResultText.text = " / 완료";
                    showQuestWindow();
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
    public void MakeBridge(){
        QuestCurrentText.text = "완료";
    }

    void build()
    {
        if (Eff_Title_Opening == null)
        {
            return;
        }
        buildNPC[0].SetActive(false);
        buildNPC[1].SetActive(false);
        buildNPCDIS[0].SetActive(true);
        buildNPCDIS[1].SetActive(true);
        Eff_Title_Opening.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        bridge.SetActive(true);
        birdgeBlock.SetActive(false);
    }

    IEnumerator Count(float target, float current)

    {
        
        int count = 0;
        while (count < 3)
        {

            Arrow.SetActive(true);
            yield return new WaitForSeconds(0.3f);
            Arrow.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            if (count == 2)
            {
                moneydown.loop = false;
                moneydown.Play();
            }
            count++;
        }



        float duration = 1f; // 카운팅에 걸리는 시간 설정. 

        float offset = (current - target) / duration; // 



        while (current > target)

        {
            current -= offset * Time.deltaTime;

            Debug.Log(current);

            Money.text = ((int)current).ToString();

            yield return null;

        }



        current = target;

        Money.text = ((int)current).ToString();


        int count2 = 0;
        while (count2 < 2)
        {
            yield return new WaitForSeconds(0.3f);
            yield return new WaitForSeconds(0.3f);
            
            yield return new WaitForSeconds(0.1f);
            count2++;
        }


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
        StartCoroutine(Down(letter));

    }
    
    public void dis()
    {
        coinUp.SetActive(false);
        coinUp.transform.Translate(0, 0, 0);
    }
}

