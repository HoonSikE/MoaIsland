using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ProblemManager : MonoBehaviour
{
    public List<QuestionAndAnswers> QnA;
    public QuestionAndAnswers newQuestion1 = new QuestionAndAnswers();
    public QuestionAndAnswers newQuestion2 = new QuestionAndAnswers();
    public QuestionAndAnswers newQuestion3 = new QuestionAndAnswers();
    public QuestionAndAnswers newQuestion4 = new QuestionAndAnswers();
    public QuestionAndAnswers newQuestion5 = new QuestionAndAnswers();

    string[] answers1 = {
        "부모님 생신 선물을 사기 위해 돈을 모으는 친구", 
        "책을 좋아해서 한 달에 1권씩 책을 사는 친구",
        "모바일 게임에 너무 과금해서 간식을 사 먹을 돈도 없는 친구", 
        "일주일에 3000원씩 저축하는 친구" };
    string[] answers2 = {
        "이자",
        "투자",
        "환율",
        "세금" };
    string[] answers3 = {
        "우리 모두가 행복해지게 의무적으로 내야 하는 돈이다.",
        "은행에서 돈을 빌리는 행위이다.",
        "사회에 꼭 필요한 곳에 쓰기 위해 내는 돈이다.",
        "기업의 일부를 사서 버는 돈을 나누어 가지는 것이다." };
    string[] answers4 = {
        "사회에 꼭 필요한 곳에 쓰기 위해서예요.",
        "멋있는 장난감을 살 수 있어요.",
        "내가 가지고 있는 돈을 불릴 수 있어요.",
        "나만 내면 억울해요." };
    string[] answers5 = {
        "은행에 돈을 저축하는 행위",
        "은행에 돈을 빌리는 행위",
        "다른 나라에서 상품을 사오는 행위",
        "사회에 꼭 필요한 곳에 쓰기 위해 내는 돈" };

    string[] description1 = { 
        "돈을 모으는 이유와 방법이 적절해요.", 
        "취미를 위해 적절하게 돈을 잘 썼어요.", 
        "모바일 게임에 과하게 돈을 쓰는 것은 좋지 않아요.",
        "규칙적으로 돈을 잘 저금했어요." };
    string[] description2 = {
        "이자는 예금을 넣어서 받을 수 있는 추가적인 돈입니다.",
        "투자는 이익을 얻기 위해 어떤 일이나 사업에 돈과 시간을 쏟는 거에요.",
        "환율은 나라 간 돈 가치의 차이입니다.",
        "세금은 모든 사람의 행복을 위해 의무적으로 내는 돈입니다." };
    string[] description3 = {
        "세금에 대한 설명입니다.",
        "대출에 대한 설명입니다.",
        "세금에 대한 설명입니다.",
        "주식에 대한 설명입니다." };
    string[] description4 = {
        "세금이 필요한 이유입니다.",
        "장난감은 개인의 행복을 위해 사는 것입니다.",
        "투자에 대한 설명입니다.",
        "세금은 모두의 행복을 위해 모으는 돈입니다." };
    string[] description5 = {
        "예금에 대한 설명입니다.",
        "대출에 대한 설명입니다.",
        "수입에 대한 설명입니다.",
        "세금에 대한 설명입니다." };


    public GameObject[] options;
    public GameObject[] optionsResult;
    public int[] counting;
    public GameObject[] checkImages;
    public int currentQuestion;

    public GameObject QuizPanel;
    public GameObject Retry;
    public GameObject Capture;

    public TextMeshProUGUI QuestionText;
    public TextMeshProUGUI QuestionNumber;
    public GameObject QuestionDescription;
    public TextMeshProUGUI ScoreText;
    public TextMeshProUGUI ScoreDescription;

    public AudioSource CorrectSound;
    public AudioSource WrongSound;

    float totalQuestions = 0;
    int questionCount;
    public float score;

    public bool isCorrect = false;
    public int currentIndex;
    public int currentPage;

    private string resultColor = "#FD3535";

    public GameObject StartCanvas;
    public GameObject InformationCanvas;
    public GameObject ProblemCanvas;
    public GameObject CertificateCanvas;

    private void Awake()
    {
        currentPage = 0;
        currentIndex = -1;
        questionCount = 0;

        StartCanvas.SetActive(false);
        InformationCanvas.SetActive(false);
        ProblemCanvas.SetActive(true);
        CertificateCanvas.SetActive(false);
    }

    private void Start()
    {
        totalQuestions = QnA.Count;
        //GoPanel.SetActive(false);
        Retry.SetActive(false);
        Capture.SetActive(false);
        GenerateQuestion();
        QuestionDescription.SetActive(false);
    }

    public void retry()
    {
        currentPage = 0;
        currentIndex = -1;
        questionCount = 0;
        score = 0;

        newQuestion1.Question = "다음 중 잘못된 소비 습관을 가진 친구를 골라보세요.";
        newQuestion1.Answers = answers1;
        newQuestion1.Descriptions = description1;
        newQuestion1.CorrectAnswer = 3;

        newQuestion2.Question = "은행에 돈을 맡기는 것을 예금이라고 합니다. 예금을 하면 일정 기간마다 돈이 늘어나는데요, 이때 불어난 돈을 무엇이라고 할까요?";
        newQuestion2.Answers = answers2;
        newQuestion2.Descriptions = description2;
        newQuestion2.CorrectAnswer = 1;

        newQuestion3.Question = "주식에 대한 설명으로 옳은 것을 골라보세요.";
        newQuestion3.Answers = answers3;
        newQuestion3.Descriptions = description3;
        newQuestion3.CorrectAnswer = 4;

        newQuestion4.Question = "세금을 내야 하는 이유에 대해 옳은 것을 골라보세요.";
        newQuestion4.Answers = answers4;
        newQuestion4.Descriptions = description4;
        newQuestion4.CorrectAnswer = 1;

        newQuestion5.Question = "대출에 대한 설명으로 옳은 것을 골라보세요";
        newQuestion5.Answers = answers5;
        newQuestion5.Descriptions = description5;
        newQuestion5.CorrectAnswer = 2;

        QnA.Add(newQuestion1);
        QnA.Add(newQuestion2);
        QnA.Add(newQuestion3);
        QnA.Add(newQuestion4);
        QnA.Add(newQuestion5);

        totalQuestions = QnA.Count;
        for (int i = 0; i < optionsResult.Length; i++)
        {
            counting[i] = 0;
            checkImages[i].SetActive(false);
        }

        GenerateQuestion();
        QuestionDescription.SetActive(false);

        Retry.SetActive(false);
        Capture.SetActive(false);
        QuizPanel.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void capture()
    {
        ProblemCanvas.SetActive(false);
        CertificateCanvas.SetActive(true);
        //SceneManager.LoadScene(10);
    }

    void GameOver()
    {
        QuizPanel.SetActive(false);
        //GoPanel.SetActive(true);
        ScoreText.text = ((score / totalQuestions) * 100).ToString() + "점";
        if ((score / totalQuestions) * 100 >= 60)
        {
            Capture.SetActive(true);
            ScoreDescription.text = "60점 이상 취득하였습니다. 수료증을 발급받을 수 있습니다.";
        }
        else
        {
            Retry.SetActive(true);
            ScoreDescription.text = "60점이 넘지 않았습니다. \n 수료증을 받기 위해서 다시 풀어보세요.";
        }
    }

    public void Correct()
    {
        // when you are right
        score++;
        QuestionText.text = $"<size=200><color={resultColor}>정답입니다</color></size>";
        CorrectSound.Play();
        GenerateQuestion();
    }

    public void Wrong()
    {
        // when you answer wrong
        QuestionText.text = $"<size=200><color={resultColor}>틀렸습니다</color></size>";
        WrongSound.Play();
        GenerateQuestion();
    }

    void SetAnswers()
    {
        for (int i = 0; i < options.Length; i++)
        {
            options[i].GetComponent<AnswerScript>().isCorrect = false;
            options[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = QnA[currentQuestion].Answers[i];
            if (QnA[currentQuestion].CorrectAnswer == i + 1)
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
                questionCount += 1;
                QuestionNumber.text = questionCount.ToString();
            }
            // 문제 페이지 (두 번째 문제부터)
            else if (currentPage % 2 == 0)
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
                QuestionDescription.SetActive(false);
                questionCount += 1;
                QuestionNumber.text = questionCount.ToString();
            }
            // 해설 페이지 (currentPage%2 == 1)
            else
            {
                SetResults();
                QuestionDescription.SetActive(true);
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
