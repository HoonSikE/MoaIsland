using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public ProblemManager quizManager;
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
        // ���� �������̰� ���� �����ߴٸ� ���� �������� �Ѿ��
        if (quizManager.currentPage % 2 == 0 && quizManager.currentIndex != -1)
        {
            quizManager.currentPage++;
            if (quizManager.options[quizManager.currentIndex].GetComponent<AnswerScript>().isCorrect == true)
            {
                //Debug.Log("Correct Answer");
                quizManager.Correct();
            }
            else
            {
                //Debug.Log("Wrong Answer");
                quizManager.Wrong();
            }
        }
        // �ؼ� �������̰� �ƹ��͵� �������� �ʾƵ� �Ѿ��
        else if (quizManager.currentPage % 2 == 1)
        {
            quizManager.currentPage++;
            quizManager.GenerateQuestion();
        }
    }
}
