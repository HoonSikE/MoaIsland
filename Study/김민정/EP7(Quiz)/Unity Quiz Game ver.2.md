# Unity Quiz Game ver.2



**EP7. 퀴즈 게임 구현**

* ver.1
  * 5문제 질문 나온다.
  * 맞은 개수를 보여준다.

* ver.2
  * 5문제 질문, 해설 나온다.
  * 맞은 개수를 보여준다.
  * 질문은 선택하지 않으면 다음으로 넘어가지 않는다.
  * 해설의 경우는 아무것도 선택하지 않아도 넘어간다.

<br>

### QuizManager.cs

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

    public void correct()
    {
        // when you are right
        score++;
        //QnA.RemoveAt(currentQuestion);
        GenerateQuestion();
    }

    public void wrong()
    {
        //SetResults();
        // when you answer wrong
        //QnA.RemoveAt(currentQuestion);
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
        for (int i = 0; i < options.Length; i++)
        {
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Descriptions[i];
        }
    }

    public void GenerateQuestion()
    {
        //Debug.Log(currentPage);
        if (currentPage < 10)
        {
            if (currentPage == 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                SetAnswers();
                currentIndex = -1;
            }
            else if (currentPage%2 == 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                SetAnswers();
            }    
            else    // currentPage%2 == 1(해설 페이지)
            {
                SetResults();
                currentIndex = -1;
                QnA.RemoveAt(currentQuestion);
            }
        }
        else
        {
            GameOver();
        }

    }
}
```





### AnswerScript.cs

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

    public void Answer()
    {
        //Debug.Log(quizManager.currentPage);
        // 질문 페이지이고 답을 선택했다면 다음 페이지로 넘어가기
        if (quizManager.currentPage % 2 == 0 && quizManager.currentIndex != -1)
        {
            quizManager.currentPage++;
            //Debug.Log(quizManager.currentIndex);
            if (quizManager.options[quizManager.currentIndex].GetComponent<AnswerScript>().isCorrect == true)
            {
                Debug.Log("Correct Answer");
                quizManager.correct();
            }
            else
            {
                Debug.Log("Wrong Answer");
                quizManager.wrong();
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

