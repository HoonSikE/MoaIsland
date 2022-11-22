using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene4 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {
        // 주식섬 소개
        talkData.Add(1000, new string[] {
            "주주:안녕! 여기는 주식섬이야! 오늘도 돈을 벌어보자고~",
            });
        talkData.Add(2000, new string[] {
            "까망이:오늘도 열심히 생선을 팔아야지!",
        });
        talkData.Add(3000, new string[] {
            "얼룩이:일하기 싫어~ 사탕만 먹고 싶어~",
        });
        // 좋아하는 것 선택
        talkData.Add(10 + 1000, new string[] {
            //"주주:그거 알아? 자신이 좋아하는 걸로도 돈을 벌 수 있어.",
            "주주:갑작스럽지만, 넌 평소에 무엇을 하며 시간을 보내니?",
            "주주:다음 화면 선택지에서 골라줘!!"
            });
        // 선택 UI
        talkData.Add(11 + 1000, new string[] {
            //"주식:게임, 운동, 유튜브",
            // "주식: ",
            "주주:SelectOne",
            });

        // 주식 개요
        talkData.Add(12 + 1000, new string[] {
            "주주:너도 그렇구나! 나도 그렇게 시간을 보내고는 해~",
            "주주:너와 나 말고도 많은 사람들이 그렇게 시간을 보내니, 이런 서비스를 제공하는 회사들은 돈을 엄청 많이 벌겠지?",
            "주주:그런 회사들이 버는 돈을 나눠받을 수 있는 방법이 있어",
            "주주:회사를 아주 잘게 나눠서, 그 중 일부를 사는 거야!",
            "주주:그럼 우리는 그 회사가 버는 돈의 일부를 나눠 가질 수 있어",
            });
        // 주식 설명 UI
        talkData.Add(13 + 1000, new string[] {
            // "주식: ",
            "주주:PopUpOne",
            // (이렇게 기업의 일부를 사는 대신~~~~~
            });

        // 주식 기업 선택
        talkData.Add(20 + 1000, new string[] {
            "주주:하지만 아무 주식이나 사서 돈을 벌 수 있는 건 아니겠지?", 
            "주주:그럼 지금부터 어떤 회사의 주식을 사야 돈을 벌 수 있을지 한 번 경험해볼까?",
            "주주:섬에 있는 가게들의 주인을 찾아가서 정보를 얻어보자",
            });
        talkData.Add(21 + 1000, new string[] {
            "주주:가게는 머리 위의 방향표를 따라가면 찾을 수 있어!",
            });
        // 기업1
        talkData.Add(21 + 2000, new string[] {
            "까망이:난 생선 회사의 사장이야.",
            "까망이:어… 잠깐만 전화 좀 받고 올게.",
            "까망이:여보세용? 아 네네, 맞습니다, 네, 잘 부탁드립니다.",
            "까망이:아이고 미안해~ 요즘 정말 바빠서 말이야… 잠도 잘 못 자고 있네 허허허",
            "까망이:혹시 자네도 생선을 먹고 싶다면 우리 회사에 들러주게, 손님은 언제나 환영이니!",
            });
        //talkData.Add(22 + 2000, new string[] {
        //    "까망이:오늘도 열심히 생선을 팔아야지!",
        //    });
        // 기업2
        talkData.Add(22 + 3000, new string[] {
            "얼룩이:난 사탕 회사의 사장이야.",
            "얼룩이:사실 난 사탕이 너무 좋아. 매일 밤 사탕을 한 움쿰씩 집으로 가져와서 먹고 있어.",
            "얼룩이:난 사장이니까 그 정도 쯤은 괜찮지 않아? 아 사탕 먹고 싶다!",
            });
        //talkData.Add(23 + 3000, new string[] {
        //    "얼룩이:일하기 싫어~ 사탕만 먹고 싶어~",
        //    });
        // 기업 선택
        talkData.Add(23 + 1000, new string[] {
            "주주:어떤 회사에 투자할지 결정했어?",
            "주주:다음 화면 선택지에서 투자할 기업을 선택해 봐!!"
            });
        // 기업 선택 UI
        talkData.Add(24 + 1000, new string[] {
            // "주식: ",
            "주주:SelectTwo",
            });
        // 주식 결과 UI (좋은 기업)
        talkData.Add(25 + 1000, new string[] {
            // "주식: ",
            "주주:똑똑하구나! 좋은 회사를 골랐어!:Newspaper",
            });
        // 주식 결과 UI (나쁜 기업)
        talkData.Add(26 + 1000, new string[] {
            "주주:하하! 이 세상에 무조건 돈을 많이 버는 게 어디 있겠니~:Newspaper",
            });
        // 주식 주의 사항
        talkData.Add(27 + 1000, new string[] {
            // "주식: ",
            "주주:PopUpTwo",
            });
        // 좋은 기업 결과
        talkData.Add(28 + 1000, new string[] {
            // "주식:똑똑하구나! 좋은 기업을 골랐어!",
            "주주:나쁜 회사의 주식을 선택할 경우 돈을 잃을 수도 있으니, 앞으로도 주식을 살 때는 신중하게 선택하도록 하자!",
            });
        // 나쁜 기업 결과
        talkData.Add(29 + 1000, new string[] {
            // "주식:하하! 이 세상에 무조건 돈을 많이 버는 게 어디 있겠니~",
            "주주:그러니 앞으로 주식을 살 때는 신중하게 선택하도록 하자",
            });
        // 다음 섬 이동
        talkData.Add(30 + 1000, new string[] {
            "주주:자 이제 주식에 대해서 조금 알 것 같니?",
            "주주:그럼 다음 섬으로 넘어가 볼까?",
            });
        talkData.Add(31 + 1000, new string[] {
            "주주:다음 섬으로 넘어가기 위해서는 섬의 왼쪽 부두에 가면 돼!",
        });
    }
    // 해당 스크립트 내용을 불러온다.
    public string GetTalk(int id, int talkIndex)
    {
        // // 키에 값이 들어있다면
        // if(talkData.ContainsKey(id)){
        //     if(talkIndex == talkData[id].Length)
        //         return null;
        //     else
        //     {
        //         return talkData[id][talkIndex];
        //     }
        // }
        // return null;

        // 키에 값이 없다면
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
