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
        "�θ�� ���� ������ ��� ���� ���� ������ ģ��", 
        "å�� �����ؼ� �� �޿� 1�Ǿ� å�� ��� ģ��",
        "����� ���ӿ� �ʹ� �����ؼ� ������ �� ���� ���� ���� ģ��", 
        "�����Ͽ� 3000���� �����ϴ� ģ��" };
    string[] answers2 = {
        "����",
        "����",
        "ȯ��",
        "����" };
    string[] answers3 = {
        "�츮 ��ΰ� �ູ������ �ǹ������� ���� �ϴ� ���̴�.",
        "���࿡�� ���� ������ �����̴�.",
        "��ȸ�� �� �ʿ��� ���� ���� ���� ���� ���̴�.",
        "����� �Ϻθ� �缭 ���� ���� ������ ������ ���̴�." };
    string[] answers4 = {
        "��ȸ�� �� �ʿ��� ���� ���� ���ؼ�����.",
        "���ִ� �峭���� �� �� �־��.",
        "���� ������ �ִ� ���� �Ҹ� �� �־��.",
        "���� ���� ����ؿ�." };
    string[] answers5 = {
        "���࿡ ���� �����ϴ� ����",
        "���࿡ ���� ������ ����",
        "�ٸ� ���󿡼� ��ǰ�� ����� ����",
        "��ȸ�� �� �ʿ��� ���� ���� ���� ���� ��" };

    string[] description1 = { 
        "���� ������ ������ ����� �����ؿ�.", 
        "��̸� ���� �����ϰ� ���� �� ����.", 
        "����� ���ӿ� ���ϰ� ���� ���� ���� ���� �ʾƿ�.",
        "��Ģ������ ���� �� �����߾��." };
    string[] description2 = {
        "���ڴ� ������ �־ ���� �� �ִ� �߰����� ���Դϴ�.",
        "���ڴ� ������ ��� ���� � ���̳� ����� ���� �ð��� ��� �ſ���.",
        "ȯ���� ���� �� �� ��ġ�� �����Դϴ�.",
        "������ ��� ����� �ູ�� ���� �ǹ������� ���� ���Դϴ�." };
    string[] description3 = {
        "���ݿ� ���� �����Դϴ�.",
        "���⿡ ���� �����Դϴ�.",
        "���ݿ� ���� �����Դϴ�.",
        "�ֽĿ� ���� �����Դϴ�." };
    string[] description4 = {
        "������ �ʿ��� �����Դϴ�.",
        "�峭���� ������ �ູ�� ���� ��� ���Դϴ�.",
        "���ڿ� ���� �����Դϴ�.",
        "������ ����� �ູ�� ���� ������ ���Դϴ�." };
    string[] description5 = {
        "���ݿ� ���� �����Դϴ�.",
        "���⿡ ���� �����Դϴ�.",
        "���Կ� ���� �����Դϴ�.",
        "���ݿ� ���� �����Դϴ�." };


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

        newQuestion1.Question = "���� �� �߸��� �Һ� ������ ���� ģ���� ��󺸼���.";
        newQuestion1.Answers = answers1;
        newQuestion1.Descriptions = description1;
        newQuestion1.CorrectAnswer = 3;

        newQuestion2.Question = "���࿡ ���� �ñ�� ���� �����̶�� �մϴ�. ������ �ϸ� ���� �Ⱓ���� ���� �þ�µ���, �̶� �Ҿ ���� �����̶�� �ұ��?";
        newQuestion2.Answers = answers2;
        newQuestion2.Descriptions = description2;
        newQuestion2.CorrectAnswer = 1;

        newQuestion3.Question = "�ֽĿ� ���� �������� ���� ���� ��󺸼���.";
        newQuestion3.Answers = answers3;
        newQuestion3.Descriptions = description3;
        newQuestion3.CorrectAnswer = 4;

        newQuestion4.Question = "������ ���� �ϴ� ������ ���� ���� ���� ��󺸼���.";
        newQuestion4.Answers = answers4;
        newQuestion4.Descriptions = description4;
        newQuestion4.CorrectAnswer = 1;

        newQuestion5.Question = "���⿡ ���� �������� ���� ���� ��󺸼���";
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
        ScoreText.text = ((score / totalQuestions) * 100).ToString() + "��";
        if ((score / totalQuestions) * 100 >= 60)
        {
            Capture.SetActive(true);
            ScoreDescription.text = "60�� �̻� ����Ͽ����ϴ�. �������� �߱޹��� �� �ֽ��ϴ�.";
        }
        else
        {
            Retry.SetActive(true);
            ScoreDescription.text = "60���� ���� �ʾҽ��ϴ�. \n �������� �ޱ� ���ؼ� �ٽ� Ǯ�����.";
        }
    }

    public void Correct()
    {
        // when you are right
        score++;
        QuestionText.text = $"<size=200><color={resultColor}>�����Դϴ�</color></size>";
        CorrectSound.Play();
        GenerateQuestion();
    }

    public void Wrong()
    {
        // when you answer wrong
        QuestionText.text = $"<size=200><color={resultColor}>Ʋ�Ƚ��ϴ�</color></size>";
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
            // ���� (ù ��° ���� ������)
            if (currentPage == 0)
            {
                currentQuestion = Random.Range(0, QnA.Count);
                QuestionText.text = QnA[currentQuestion].Question;
                SetAnswers();
                currentIndex = -1;
                questionCount += 1;
                QuestionNumber.text = questionCount.ToString();
            }
            // ���� ������ (�� ��° ��������)
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
            // �ؼ� ������ (currentPage%2 == 1)
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

                // ������ �亯�� ���� ä�� ���(button ����)
                //if (options[currentIndex].GetComponent<AnswerScript>().isCorrect == true)
                //{
                //    ColorBlock YesColors = options[currentIndex].GetComponent<Button>().colors;
                //    YesColors.normalColor = new Color32(69, 199, 247, 225);
                //    options[currentIndex].GetComponent<Button>().colors = YesColors;
                //}

                QnA.RemoveAt(currentQuestion);
            }
        }
        // ���� ����
        else
        {
            GameOver();
        }

    }

}
