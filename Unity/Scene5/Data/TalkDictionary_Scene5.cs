using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene5 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        talkData.Add(100, new string[] {
            "#####:응..!?",
            "#####:왜 돈이 줄어드는거야!?!?",
            "#####:돈이 줄어든 이유를 용용이에게 물어보자!!",
            });

        talkData.Add(1+1000, new string[] {
            "용용이:안녕, 이제 집에 돌아갈 준비가 다 되었구나!",
            "용용이:이 곳에 처음 도착했을 때 돈이 줄어들었지?",
            "용용이:그 돈이 다리를 만들기 위해 쓰인 세금이야",
            
            //세금:세금이란 모든 사람의 행복을 위해 의무적으로 내는 돈입니다. 이렇게 낸 세금은 사회에 꼭 필요한 곳에 다양하게 쓰여요!",
            //"세금:그런데 아직 [오도석]이 세금을 내지 않았어. 가서 [오도석]을 설득해 줄래?",
            });
        talkData.Add(2 + 1000, new string[] {
            "팝업:팝업"
            });
        talkData.Add(3 + 1000, new string[] {
            "용용이:세금을 모아서 다리를 만들려고 해!",
            "용용이:그런데 아직 너굴이가 세금을 내지 않았어. 너굴이를 찾아서 세금을 낼 수 있게 도와줄래?",
            });

        // 미납자를 찾으러 가보자.
        talkData.Add(10 + 2000, new string[] {
            "#####:안녕 혹시 네가 너굴이니?",
            "너굴이:응 맞아! 무슨 일이야?",
            "#####:네가 세금을 내지 않았다고 해서 찾아왔어",
            "너굴이:세금? 세금이 뭔데?",
            "#####:세금은 모든 사람의 행복을 위해 의무적으로 내야 하는 돈이야.",
            "#####:모두를 위한 다리를 만드는 데 너의 세금이 필요해!",
            "너굴이:아 그렇구나! 세금은 모두를 위해 꼭 필요한 돈이구나!",
            "너굴이:여기있어!!",
            "#####:용용이에게 돌아가자!!"
            });

        // 세금 NPC로 돌아옴.
        // 다리 건설
        talkData.Add(20 + 1000, new string[] {
            "용용이:고마워!!! 덕분에 다리를 건설할 수 있겠어!!",
            });
        /* 애니메이션 2.0f*/
        // 다리 건설 완료
        talkData.Add(21 + 1000, new string[] {
            "용용이:다함께 다리를 만들고 있어 잠시만 기다려줘!",
            });
        /* Fade In/Out 1.5f */
        talkData.Add(22 + 1000, new string[] {
            "용용이:모두가 세금을 내준덕분에 다리가 완성되었어!!",
            });
        /* 이어주자 */
        // 다음 섬 이동
        talkData.Add(30 + 1000, new string[] {
            "용용이:만들어진 다리를 건너서 다음 섬으로 이동해보자!!!",
            });
    }
    // 해당 스크립트 내용을 불러온다.
    public string GetTalk(int id, int talkIndex){
        // 키에 값이 들어있다면
        if(talkData.ContainsKey(id)){
            if(talkIndex == talkData[id].Length)
                return null;
            else
                return talkData[id][talkIndex];
        }
        return null;
    }
}
