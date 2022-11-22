using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene0 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        talkData.Add(0, new string[] {
            "???:오늘도 게임에 돈을 써볼까~??",
            });
        talkData.Add(1 + 0, new string[] {
            "유령:이 녀석!!! 돈을 이렇게 흥청망청 쓰다니!!!",
            "유령:정신 차릴 때까지 벌을 주겠어!"
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
