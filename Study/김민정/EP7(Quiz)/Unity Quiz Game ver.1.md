# Unity 퀴즈 만들기

> https://www.youtube.com/watch?v=G9QDFB2RQGA



1. 2D 캔버스 생성 후 Panel 만들기 (background)

2. Canvas 아래 Panel 생성

   * QuestionPanel(Panel) > QuestionText
   * Button
   * Button (1)
   * Button (2)
   * Button (3)

3. Panel 하위 object들에 shadow 걸기

4. Create Empty(Canvas랑 동일 위치에서) > 'QuizManager' 생성

5. QuizManager컴포넌트에 QuizManager.cs 스크립트 만들고 넣기

   ```c#
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   using UnityEngine.UI;
   using TMPro;
   using UnityEngine.SceneManagement;
   
   
   public class QuizManager : MonoBehaviour
   {
       public List<QuestionAndAnswers> QnA;
       public GameObject[] options;
       public int currentQuestion;
   
       public GameObject QuizPanel;
       public GameObject GoPanel;
   
       public TextMeshProUGUI QuestionText;
       public TextMeshProUGUI ScoreText;
   
       int totalQuestions = 0;
       public int score;
   
       private void Start()
       {
           totalQuestions = QnA.Count;
           GoPanel.SetActive(false);
           generateQuestion();
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
           QnA.RemoveAt(currentQuestion);
           generateQuestion();
       }
   
       public void wrong()
       {
           // when you answer wrong
           QnA.RemoveAt(currentQuestion);
           generateQuestion();
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
   
       void generateQuestion()
       {
           if (QnA.Count > 0)
           {
               currentQuestion = Random.Range(0, QnA.Count);
               QuestionText.text = QnA[currentQuestion].Question;
               SetAnswers();
           }
           else
           {
               //Debug.Log("Out of Questions");
               GameOver();
           }
   
       }
   }
   ```

   

6. QuestionAndAnswers.cs 생성

   ```c#
   
   [System.Serializable]
   public class QuestionAndAnswers
   {
       public string Question;
       public string[] Answers;
       public int CorrectAnswer;
   }
   ```

   

7. AnswerScript.cs 생성

   ```c#
   using System.Collections;
   using System.Collections.Generic;
   using UnityEngine;
   
   public class AnswerScript : MonoBehaviour
   {
       public bool isCorrect = false;
       public QuizManager quizManager;
   
       public void Answer()
       {
           if(isCorrect)
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
   }
   ```

   