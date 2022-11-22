using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalkNPC : MonoBehaviour
{
    //public NPCVoice npcvoice;
    public AudioSource npcVoice;
    public GameObject talkPanel;
    // 유저 이름
    public Text userText;
    // 대화 내용
    public Text talkText;
    // Start is called before the first frame update
    void Start()
    {
        //npcvoice = FindObjectOfType<NPCVoice>();
        talkPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Shark")
        {

            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "샥샥";
            talkText.text = "안녕! 세금섬에 온걸 환영해!";

        }
        if (collision.collider.tag == "Shark2")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "쇽쇽";
            talkText.text = "세금으로 다리를 만든다고 하던데...";
        }
        if (collision.collider.tag == "Cat")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "냐옹";
            talkText.text = "세금? 나는 세금을 냈어!";
        }
        if (collision.collider.tag == "Cat2")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "야옹";
            talkText.text = "발조심해!!!";
        }
        if (collision.collider.tag == "Racoon")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "쿠니";
            talkText.text = "나는 세금섬의 세금관리를 하고있어! " +
                "세금은 모두를 위한 돈이니까!!";
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Shark")
        {
            userText.text = "";
            talkText.text = "";
            talkPanel.SetActive(false);
            
        }
        if (collision.collider.tag == "Shark2")
        {
            userText.text = "";
            talkText.text = "";
            talkPanel.SetActive(false);

        }
        if (collision.collider.tag == "Cat")
        {
            userText.text = "";
            talkText.text = "";
            talkPanel.SetActive(false);

        }
        if (collision.collider.tag == "Cat2")
        {
            userText.text = "";
            talkText.text = "";
            talkPanel.SetActive(false);

        }
        if (collision.collider.tag == "Racoon")
        {
            userText.text = "";
            talkText.text = "";
            talkPanel.SetActive(false);

        }
    }
}
