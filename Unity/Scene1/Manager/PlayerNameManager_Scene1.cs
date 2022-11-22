using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerNameManager_Scene1 : MonoBehaviour
{
    // 유니티는 다른 씬으로 넘어가면 기본적으로 모든 오브젝트를 파괴함
    // 이전 씬에서 사용하던 변수나 오브젝트를 DontDestroyOnLoad를 통해 다음 씬에서도 사용 가능
    public static string playerName;
    public bool isPlayerName;

    void Awake()
    {
        isPlayerName = false;
        DontDestroyOnLoad(this);
    }

    public string GetPlayerName()
    {
        Debug.Log("플레이어 이름 호출 :" + playerName);
        return playerName;
    }

    public void SetPlayerName(string name)
    {
        Debug.Log("플레이어 이름 저장 : " + name);
        playerName = name;
        isPlayerName = true;
    }

}
