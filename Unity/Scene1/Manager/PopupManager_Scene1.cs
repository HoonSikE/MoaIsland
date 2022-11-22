using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager_Scene1 : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject BackGound;
    // ���� ��ȭ ��ư
    public GameObject ButtonNextChat;

    public void Appear()
    {
        gameObject.SetActive(true);
        BackGound.SetActive(true);

        // �������� �ѱ� �� �ִ� ��ư ��Ȱ��ȭ
        ButtonNextChat.SetActive(false);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
        BackGound.SetActive(false);

        // �������� �ѱ� �� �ִ� ��ư Ȱ��ȭ
        ButtonNextChat.SetActive(true);
    }
}
