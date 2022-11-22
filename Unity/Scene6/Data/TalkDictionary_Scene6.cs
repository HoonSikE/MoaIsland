using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene6 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        talkData.Add(0 + 0, new string[] {
            "#####:와아아! 드디어 저주가 풀렸어!",
            });

        talkData.Add(1 + 0, new string[] {
            "유령:뿅!",
            });

        talkData.Add(2 + 0, new string[] {
            "유령:모아섬을 돌아다니면서 돈을 어떻게 현명하게 써야할 지 알게 되었니?",
            "유령:앞으로는 현명한 경제 생활을 하기를 바라",
            "#####:이제부터는 돈을 어떻게 사용할지 목표를 세우고 계획적으로 써야겠어.",
            "#####:게임에 사용하는 돈은 좀 줄이고 섬에서 배웠던 것처럼 저축을 해봐야지!",
            });
        // 마무리
        talkData.Add(10 + 0, new string[] {
            "유령:그럼 퀴즈를 통해 배운점을 정리해보자!",
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
