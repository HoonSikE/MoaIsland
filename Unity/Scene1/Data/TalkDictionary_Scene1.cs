using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene1 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        talkData.Add(1000, new string[]
        {
            "튜튜:다음 섬으로 넘어가보자!",
        });

        talkData.Add(5000, new string[]
        {
            "왕왕:기차가 지나가니 조심해!"
        });

        talkData.Add(10, new string[] {
            "???:으 머리야.. 여긴 어디지? 난 누구지?",
            "???:내 이름이 뭐였더라?",
            "???:(내 이름을 입력해보자)",
            "#####:이..이게 뭐야! 내가 여우라니",
            "#####:내가 돈을 너무 많이 써서 저주를 받은거야?",
            "#####:그게 꿈이 아니었다고!?",
            "#####:앗! 저 앞에 누군가 있는 거 같아! 일단 가서 물어보자",
            "#####:(NPC에게 다가가서 Enter 키를 눌러보자)",
        });


        // 가이드에게 말을 걸어보자
        talkData.Add(20 + 1000, new string[] {
            "튜튜:#####! 저주받은 아이가 바로 너구나? 꽥꽥",
            "#####:내 저주를 풀고 싶어!",
            "튜튜:저주를 풀고 싶니? ",
            "튜튜:저주를 풀기 위해서 섬을 이동하면서 퀘스트를 깨야 해!",
            "튜튜:그전에 이곳에서 이동하는 방법을 알아야겠지?",
            "튜튜:상하좌우 방향키를 이용하면 걸을 수 있다는 건 이미 알고 있지?",
            "튜튜:Shift 키를 누르면 달리기를 할 수 있고, Space 키를 누르면 점프도 가능해!",
            });
        // 상단바 설명
        talkData.Add(21 + 1000, new string[] {
            "튜튜:왼쪽 위를 보면 네가 현재 가지고 있는 모아를 볼 수 있어! 현재는 0모아를 소지했구나!",
            "튜튜:반대로 오른쪽 위를 봐볼까?",
            "튜튜:지도 버튼을 누르면 너와 NPC 위치를 확인할 수 있어",
            "튜튜:게임을 진행하다 조작법을 잊으면 물음표 버튼을 클릭해봐",
            "튜튜:그리고 설정 버튼을 통해 게임 소리 크기를 조절할 수 있어!",
            "튜튜:마지막으로 머리 위 화살표는 네가 가야할 길을 알려주니 길이 헷갈릴 땐 화살표를 따라가면 돼"
            }) ;
            
        // 다음 섬 이동
        talkData.Add(30 + 1000, new string[] {
            "튜튜:이제 어떻게 하는지 알겠지?",
            "튜튜:왼쪽 포탈을 이용해서 다음 섬으로 이동해보자!",
            });
    }
    // 해당 스크립트 내용을 불러온다.
    public string GetTalk(int id, int talkIndex){
        // 키에 값이 들어있다면
        if (!talkData.ContainsKey(id))
        {
            if (!talkData.ContainsKey(id - id % 100))
            {
                return null;
            }
            if (talkIndex == talkData[id - id % 100].Length)
                return null;
            else
                return talkData[id - id % 100][talkIndex];
        }
        if (talkIndex == talkData[id].Length)
            return null;
        else
            return talkData[id][talkIndex];
    }
}
