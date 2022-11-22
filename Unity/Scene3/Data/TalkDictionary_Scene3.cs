using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 대화 내용을 저장
public class TalkDictionary_Scene3 : MonoBehaviour {
    // 변수 선언
    Dictionary<int, string[]> talkData;
    // 변수 초기화
    void Awake() {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }
    // 변수 초기화 (여기에 스크립트 작성!!!!!!)
    void GenerateData() {

        talkData.Add(2000, new string[]
        {
            "통통:만나서 반가워. 은행섬에 온 걸 환영해"
        });

        talkData.Add(3000, new string[]
{
            "동동:난 은행에 벌써 10만 모아나 모았어!",
            "동동:넌 얼마나 모았니?"
});

        // 은행섬 소개
        talkData.Add(1000, new string[] {
            "뱅뱅:어서와! 여기는 은행섬이야. 난 은행섬에서 일 하고 있는 뱅뱅이라고 해",
            "뱅뱅:은행은 처음이지?",
            "#####:응 은행은 처음이야",
            "뱅뱅:혹시 은행이 어떤 곳인지 아니?",
            "#####:은행이 어떤 곳인데?",
            "뱅뱅:내가 지금부터 간단하게 알려줄게",
            "뱅뱅:은행은 돈을 맡겨두는 곳이야",
            "#####:왜 집에 두지 않고 은행에 맡기는거야?",
            // "뱅뱅:그럼 집에 두지 왜 은행까지 와서 맡기냐고?",
            "뱅뱅:왜냐면 은행에 돈을 맡겨두면 안전하게 보관도 할 수 있고 돈을 불려주기까지 하거든! 굉장하지?",
            "뱅뱅:그럼 은행은 어떻게 이용할 수 있을까?",
            "뱅뱅: 은행에 돈을 맡기기 위해서는 먼저 통장이라는 것이 필요해",
            "#####:통장? 통장은 어떻게 얻을 수 있어?",
            "뱅뱅:저쪽으로 가면 통장을 만들어주는 통통이를 찾을 수 있을 수 있어",
            "뱅뱅:통통이를 만나 통장을 만들고 돌아와!"
            });

        talkData.Add(10 + 1000, new string[]
        {
            "뱅뱅: 아직 통통이를 만나지 못한거야? 저 쪽으로 가봐"
        });

        // 통장 npc를 찾으러 가보자.
        talkData.Add(10 + 2000, new string[] {
            "통통:안녕! 통장을 만들러 왔니? ",
            "#####:응! 은행을 이용하기 위해서는 통장이 필요하대",
            "통통:원래 어린이들이 통장을 만들기 위해서는 부모님이랑 같이 와야 하지만, 오늘은 특별히 내가 만들어 줄게",
            "#####:와 정말 고마워!",
            "통통:통장을 만들기 위해서는 사인이 필요해",
            "통통:여기에 사인을 해줄래?!",
            "통통:와! 정말 멋진 사인이구나!",
            "통통:그럼 통장을 만들어 줄게. 잠깐만 기다렸다가 다시 말을 걸어줘",
            });

        talkData.Add(11 + 1000, new string[]
        {
            "뱅뱅: 은행을 이용하기위해서는 통장이 필요해! "
        });

        talkData.Add(11 + 2000, new string[] {
            "통통:자! 통장이 만들어졌어. 만든 통장을 이용하려면 다시 뱅뱅이에게 가봐!",
            });

/*        // 통장 싸인 폼
        talkData.Add(11 + 2000, new string[] {
            "통장:통장에 싸인을 해줘!!",
            });
        // 통장 싸인 완료
        talkData.Add(12 + 2000, new string[] {
            "통장:와 정말 멋진 사인이구나!",
            "통장:자! 통장이 만들어졌어. 만든 통장을 이용하려면 다시 [은행 npc]에게 가봐!",
            });*/


        talkData.Add(20 + 2000, new string[] {
            "통통:뱅뱅이를 만나려면 저쪽으로 가야해~",
            });

        // 입급
        talkData.Add(20 + 1000, new string[] {
            "뱅뱅:통장을 만들어 왔구나. 이제 은행에 돈을 넣어볼까?",
            "뱅뱅:돈이 잘 들어갔네!",
            "#####:은행에 돈을 넣으면 돈이 불어난다고 했는데...",
            "뱅뱅:돈이 불어난다고 하지 않았냐고? 그러기 위해서는 시간이 필요해~",
            "#####:그럼 지금 당장은 불어날 수 없는거야?",
            // "뱅뱅:뭐? 조금 더 빨리 받을 수는 없냐고?",
            "뱅뱅:어쩔 수 없지~ 오늘은 내가 특별히 힘을 써볼게!",
            "뱅뱅:짜잔! 이제 돈이 늘어났지? 이게 바로 이자라는거야",
            "#####:우와 정말 돈이 늘어났잖아?",
            "뱅뱅:네가 돈을 넣으면, 은행에서는 그 돈을 다른 사람들에게 빌려줄 수 있어",
            "뱅뱅:그렇게 돈을 빌려준 대가로 사람들은 은행에서 맡긴 돈보다 더 많은 돈을 받을 수 있지",
            "#####:그렇구나!",
            "뱅뱅:그럼 이제 불어난 돈을 찾아볼까?",
            "뱅뱅:처음에 맡긴 돈은 10,000모아였는데, 이제는 12,000모아가 됐네!",
            "뱅뱅:이제 은행에서 하는 있는 일들을 잘 배웠지?",
            "#####:응! 돌아가면 나도 은행을 이용해보고싶어",
            "뱅뱅:흠.. 그런데 은행에만 돈을 넣어두면 되는 걸까?",
            "뱅뱅:사실 다른 방법도 있어!",
            "#####:다른 방법?",
            "뱅뱅:응! 다음 섬에서 돈을 잘 활용할 수 있는 다른 방법을 알 수 있을거야!",
            "뱅뱅:다음 섬으로 이동하고 싶으면 옆에 생기는 포탈을 타!",
            "뱅뱅:섬을 더 구경하고 이동해도 좋아!"
            });

        talkData.Add(30 + 1000, new string[] {
             "뱅뱅:은행섬 너무 예쁘지않아?"
        });

        talkData.Add(30 + 2000, new string[] {
            "통통:아까 네 사인 정말 멋졌어!"
        });
        /*        // 통장 잔액 확인 UI
                talkData.Add(21 + 1000, new string[] {
                    "은행:통장에 돈이 들어가 있는 모습을 봄",
                    });
                // 금액 확인 UI
                talkData.Add(22 + 1000, new string[] {
                    "은행:이제 돈을 확인해볼까?",
                    });
                // 불어나는 돈
                talkData.Add(23 + 1000, new string[] {
                    "은행:돈이 불어난다고 하지 않았냐고? 그러기 위해서는 시간이 필요해~",
                    "은행:뭐? 조금 더 빨리 받을 수는 없냐고?",
                    "은행:어쩔 수 없지~ 그럼 내가 특별히 힘을 써볼게!",
                    });
                // 불어나는 돈 UI
                talkData.Add(24 + 1000, new string[] {
                    "은행:부풀어 오르는 돈을 봐!!",
                    // (이렇게 은행에 돈을 맡기는 것을 예금이라고 합니다. 은행에 돈을 넣으면 그 돈이 불어나요!  그 불어난 돈을 이자라고 해요)
                    });
                // 이자/출금에 대한 설명
                talkData.Add(25 + 1000, new string[] {
                    "은행:네가 돈을 넣으면, 은행에서는 그 돈을 다른 사람들에게 빌려줄 수 있어",
                    "은행:그렇게 돈을 빌려준 대가로 사람들은 은행에서 맡긴 돈보다 더 많은 돈을 받을 수 있어.",
                    "은행:그럼 이제 불어난 돈을 찾아볼까?",
                    });
                // 통장에서 돈이 빠져가는 UI
                talkData.Add(26 + 1000, new string[] {
                    "은행:출금이 되고 있어!!!",
                    });
                // 출금 부가 설명
                talkData.Add(27 + 1000, new string[] {
                    "은행:처음에 맡긴 돈은 XXX원이었는데, 이제는 YYY원이네~",
                    });
                // 출금/대출 설명 UI
                talkData.Add(28 + 1000, new string[] {
                    "은행:출금/대출 설명 UI",
                    //(이렇게 은행에서 돈을 찾는 것을 출금이라고 합니다. 은행에서 돈을 빌리는 것을 대출이라고 합니다.)
                    });
                talkData.Add(29 + 1000, new string[] {
                    "은행:이제 은행에서 할 수 있는 일들을 잘 배웠지",
                    "은행:은행에만 돈을 넣어두면 되는 걸까?",
                    "은행:다른 방법들도 있단다.",
                    "은행:다음 섬에서 돈을 잘 활용할 수 있는 또 다른 방법을 알아보자.",
                    });
                // 다음 섬 이동
                talkData.Add(30 + 1000, new string[] {
                    "은행:다음 섬으로 이동해보자!!!",
                    });*/
    }
    // 해당 스크립트 내용을 불러온다.
    public string GetTalk(int id, int talkIndex){
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
