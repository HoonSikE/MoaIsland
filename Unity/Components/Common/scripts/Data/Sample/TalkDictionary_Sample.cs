using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Sample : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        talkData.Add(1000, new string[] {
            "과소비:여기는 \"과소비 섬\"이야",
            "과소비:네가 여태까지 어떻게 돈을 써왔는지 이 섬에서 되돌아보자.",
            "과소비:자 그럼 게시판에 네가 지난 1년간 돈을 어떻게 썼는지 적어 놓았어!",
            "과소비:게시판으로 이동해서 게시판을 보고 느낀 점을 말해줘!",
            });

        // 게시판 확인 퀘스트
        talkData.Add(10 + 2000, new string[] {
            "나:게시판이다.",
            });

        // 게시판 확인 후
        talkData.Add(11 + 1000, new string[] {
            "과소비:어떤 생각이 들어?",
            "나:역시 난 완벽해!",
            });

        // 별 모으기 퀘스트
        talkData.Add(20 + 1000, new string[] {
            "과소비:모바일 게임에 지나치게 돈을 많이 쓴 것 같지 않아?",
            "과소비:이렇게 계획 없이 돈을 쓰게 된다면 네가 꼭 필요할 때 돈을 쓰기 어렵지 않겠어?",
            "과소비:몸이 아파서 병원에 가야 한다거나, 친구 생일 선물을 사야 할 때처럼 말이야! ",
            "과소비:그래서 계획을 세워서 돈을 쓰는 게 정말 중요해.",
            "과소비:그럼 우리 같이 돈을 좀 더 현명하게 사용할 수 있는 방법을 알아볼까? ",
            "과소비:그러기 위해서는 먼저 네가 지난 1년간 사용한 돈을 다시 모아와야 할 것 같아!",
            "과소비:이 마을 곳곳에 있는 동전/별 들을 먹어서 돈을 모아와!",
            "과소비:화면의 오른쪽을 보면 네가 몇 개의 별을 모았는지 알 수 있으니 참고해! 다녀와!",
            });
        talkData.Add(21 + 1000, new string[] {
            "과소비:별이 아직 부족해. 좀 더 찾아보자!",
            });
        talkData.Add(22 + 1000, new string[] {
            "과소비:와! 다 모아왔구나!",
            });
            
        // 다음 섬 이동
        talkData.Add(30 + 1000, new string[] {
            "과소비:다음 섬에서 이렇게 모은 돈으로 무엇을 할 수 있을지 알아볼 거야.",
            "과소비:그럼 다음 섬으로 넘어가 볼까?",
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
