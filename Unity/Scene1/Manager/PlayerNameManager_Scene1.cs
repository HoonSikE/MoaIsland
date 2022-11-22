using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameManager_Scene1 : MonoBehaviour
{
    // ����Ƽ�� �ٸ� ������ �Ѿ�� �⺻������ ��� ������Ʈ�� �ı���
    // ���� ������ ����ϴ� ������ ������Ʈ�� DontDestroyOnLoad�� ���� ���� �������� ��� ����
    public static string playerName;
    public bool isPlayerName;

    void Awake()
    {
        isPlayerName = false;
        DontDestroyOnLoad(this);
    }

    public string GetPlayerName()
    {
        Debug.Log("�÷��̾� �̸� ȣ�� :" + playerName);
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        Debug.Log("�÷��̾� �̸� ���� : " + name);
        playerName = name;
        isPlayerName = true;
    }

}
