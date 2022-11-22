using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTalkNPC : MonoBehaviour
{
    //public NPCVoice npcvoice;
    public AudioSource npcVoice;
    public GameObject talkPanel;
    // ���� �̸�
    public Text userText;
    // ��ȭ ����
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
            userText.text = "����";
            talkText.text = "�ȳ�! ���ݼ��� �°� ȯ����!";

        }
        if (collision.collider.tag == "Shark2")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "���";
            talkText.text = "�������� �ٸ��� ����ٰ� �ϴ���...";
        }
        if (collision.collider.tag == "Cat")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "�Ŀ�";
            talkText.text = "����? ���� ������ �¾�!";
        }
        if (collision.collider.tag == "Cat2")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "�߿�";
            talkText.text = "��������!!!";
        }
        if (collision.collider.tag == "Racoon")
        {
            talkPanel.SetActive(true);
            npcVoice.Play();
            userText.text = "���";
            talkText.text = "���� ���ݼ��� ���ݰ����� �ϰ��־�! " +
                "������ ��θ� ���� ���̴ϱ�!!";
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
