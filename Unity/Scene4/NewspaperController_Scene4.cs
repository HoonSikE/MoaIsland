using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class NewspaperController_Scene4 : MonoBehaviour
{
    public GameObject NewspaperCanvas;
    /*private void Start()
    {
        NewspaperCanvas.SetActive(false);
    }

    private void Update()
    {
        if (GameObject.Find("GameManager").GetComponent<GameManager_Chat_LBH>().LineNum == 2)
        {
            Debug.Log(GameObject.Find("GameManager").GetComponent<GameManager_Chat_LBH>().LineNum);
            Debug.Log("�ȵǰ��� ��");
            NewspaperCanvas.SetActive(true);

        }
    }
    */
    public void CloseNewsPaper()
    {
        NewspaperCanvas.SetActive(false);
        Debug.Log("�Ź��� ��ҵ�");

    }
}
