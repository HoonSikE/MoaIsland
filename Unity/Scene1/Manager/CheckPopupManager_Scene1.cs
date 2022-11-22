using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CheckPopupManager_Scene1 : MonoBehaviour
{
    // NameCheckPopup Object
    public GameObject gameObject;
    // public GameObject Backgound;
    public Text checkMessage;

    [SerializeField]
    private TMP_InputField playerNameInputField;
    public PlayerNameManager_Components playerNameManager;
    public PopupManager_Scene1 popupManager;
    public TalkManager_Scene1 talkManager;

    private string playerName;
    public void Appear(string name)
    {
        playerName = name;
        checkMessage.text = "";
        checkMessage.text = playerName + checkMessage.text;
        gameObject.SetActive(true);
        // Backgound.SetActive(true);
    }

    public void Disappear()
    {
        gameObject.SetActive(false);
       //  Backgound.SetActive(false);
    }

    public void Submit()
    {
        playerNameManager.SetPlayerName(playerName);

        talkManager.isNameSetting = false;
        talkManager.userText.text = playerName;
        string dialog = "내 이름은 " + playerNameManager.GetPlayerName() + "! 기억났다!";
        StartCoroutine(talkManager.Typing(dialog));

        Disappear();
        popupManager.Disappear();
    }


    // CancelButton Ŭ�� �� ȣ��Ǵ� �Լ�
    public void Cancel()
    {
        Disappear();
    }
}
