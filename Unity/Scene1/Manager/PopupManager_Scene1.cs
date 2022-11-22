using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopupManager_Scene1 : MonoBehaviour
{
    public GameObject gameObject;
    public GameObject BackGound;
    // 다음 대화 버튼
    public GameObject ButtonNextChat;

    public void Appear()
    {
        gameObject.SetActive(true);
        BackGound.SetActive(true);

        // 다음으로 넘길 수 있는 버튼 비활성화
        ButtonNextChat.SetActive(false);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
        BackGound.SetActive(false);

        // 다음으로 넘길 수 있는 버튼 활성화
        ButtonNextChat.SetActive(true);
    }
}
