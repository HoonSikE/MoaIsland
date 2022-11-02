# Unity Quiz Game ver.3

**EP7. 퀴즈 게임 구현**

* ver.1
  * 5문제 질문 나온다.
  * 맞은 개수를 보여준다.
* ver.2
  * 5문제 질문, 해설 나온다.
  * 맞은 개수를 보여준다.
  * 질문은 선택하지 않으면 다음으로 넘어가지 않는다.
  * 해설의 경우는 아무것도 선택하지 않아도 넘어간다.
* ver.3
  * 질문에서 정답 페이지로 이동할 때 눌렀던 버튼의 정답 체크 (빨강, 초록)
  * 정답 페이지에서 각 버튼 클릭하면 선택지와 해설이 번갈아가면서 나온다.





## QuizManager.cs

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class QuizManager : MonoBehaviour
{

    public AnswerScript answerScript;

    public List<QuestionAndAnswers> QnA;
    public GameObject[] options;
    public GameObject[] optionsResult;
    public int[] counting;
    public GameObject[] checkImages;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject GoPanel;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI ScoreText;

    int totalQuestions = 0;
    public int score;

    public bool isCorrect = false;
    public int currentIndex;
    public int currentPage;

    private string resultColor = "#FD3535";

    private void Awake()
    {
        currentPage = 0;
        currentIndex = -1;
    }

    private void Start()
    {
        answerScript = FindObjectOfType<AnswerScript>();
        totalQuestions = QnA.Count;
        GoPanel.SetActive(false);
        GenerateQuestion();
    }

    public void retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        GoPanel.SetActive(true);
        ScoreText.text = score + "/" + totalQuestions;
    }

    public void Correct()
    {
        // when you are right
        score++;
        QuestionText.text = $"<size=200><color={resultColor}>정답입니다</color></size>";
        GenerateQuestion();
    }

    public void Wrong()
    {
        // when you answer wrong
        QuestionText.text = $"<size=200><color={resultColor}>틀렸습니다</color></size>";
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i =0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i+1)
            {
                options[i].GetComponent<AnswerScript>().isCorrect = true;
            }
        }
    }

    void SetResults()
    {
        for (int i = 0; i < optionsResult.Length; i++)
        {
            optionsResult[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Descriptions[i];
        }
    }

    public void GenerateQuestion()
    {
        if (currentPage < 10)
        {
            // 시작 (첫 번째 문제 페이지)
            if (currentPage == 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                SetAnswers();
                currentIndex = -1;
            }
            // 문제 페이지 (두 번째 문제부터)
            else if (currentPage%2 == 0)
            {
                for (int i = 0; i < optionsResult.Length; i++)
                {
                    optionsResult[i].SetActive(false);
                    options[i].SetActive(true);
                    checkImages[i].SetActive(false);
                }
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                currentIndex = -1;
                SetAnswers();
            }
            // 해설 페이지 (currentPage%2 == 1)
            else
            {
                SetResults();
                for (int i = 0; i < optionsResult.Length; i++)
                {
                    counting[i] = 0;
                    optionsResult[i].SetActive(false);
                    options[i].SetActive(true);
                }

                if (options[currentIndex].GetComponent<AnswerScript>().isCorrect == true)
                {
                    checkImages[currentIndex].GetComponent<Image>().color = new Color32(0, 255, 0, 225);
                }
                else
                {
                    checkImages[currentIndex].GetComponent<Image>().color = new Color32(253, 53, 53, 225);
                }
                
                checkImages[currentIndex].SetActive(true);

                // 선택한 답변에 대한 채점 결과(button 기준)
                //if (options[currentIndex].GetComponent<AnswerScript>().isCorrect == true)
                //{
                //    ColorBlock YesColors = options[currentIndex].GetComponent<Button>().colors;
                //    YesColors.normalColor = new Color32(69, 199, 247, 225);
                //    options[currentIndex].GetComponent<Button>().colors = YesColors;
                //}

                QnA.RemoveAt(currentQuestion);
            }
        }
        // 게임 종료
        else
        {
            GameOver();
        }

    }
}
```





## AnswerScript.cs

```c#
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public int index;
    public Button button;
    

    public void GetAnswer()
    {
        quizManager.currentIndex = index;
    }

    public void ButtonClick()
    {
        if (quizManager.currentPage%2 == 1)
        {
            quizManager.counting[index]++;
            if (quizManager.counting[index]%2 == 1)
            {
                quizManager.optionsResult[index].SetActive(true);
                quizManager.options[index].SetActive(false);
            }
            else
            {
                quizManager.optionsResult[index].SetActive(false);
                quizManager.options[index].SetActive(true);
            }
        }
    }

    public void Answer()
    {
        // 질문 페이지이고 답을 선택했다면 다음 페이지로 넘어가기
        if (quizManager.currentPage % 2 == 0 && quizManager.currentIndex != -1)
        {
            quizManager.currentPage++;
            if (quizManager.options[quizManager.currentIndex].GetComponent<AnswerScript>().isCorrect == true)
            {
                Debug.Log("Correct Answer");
                quizManager.Correct();
            }
            else
            {
                Debug.Log("Wrong Answer");
                quizManager.Wrong();
            }
        }
        // 해설 페이지이고 아무것도 선택하지 않아도 넘어가기
        else if (quizManager.currentPage % 2 == 1)
        {
            quizManager.currentPage++;
            quizManager.GenerateQuestion();
        }
    }
}
```

