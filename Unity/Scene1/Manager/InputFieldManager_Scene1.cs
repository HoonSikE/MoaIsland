using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputFieldManager_Scene1 : MonoBehaviour
{

    [SerializeField]
    private TMP_InputField playerNameInputField;
    [SerializeField]
    public Text formCheckMsg;

    public CheckPopupManager_Scene1 checkPopupManager;
    string playerName;
    void Start()
    {
        playerNameInputField.characterLimit = 5; // InputField ±ÛÀÚ ¼ö Á¦ÇÑ
        //playerNameInputField.onValueChanged.AddListener( // InputField ÀÔ·Â ½Ã ¿µ¾î, ÇÑ±Û, ¼ýÀÚ¸¸ °¡´É
        //    (word) => playerNameInputField.text = Regex.Replace(word, @"[^0-9a-zA-Z°¡-ÆR]", "")
        //);

    }
    public void Submit()
    {
        playerName = playerNameInputField.text.Trim();
        if (playerName.Length != 0)
        {
            bool flag = Regex.IsMatch(playerName, @"^[°¡-ÆR]*$");
            
            if (!flag)
            {
                Debug.Log("Àß¸øµÈ ÀÔ·Â Çü½ÄÀÔ´Ï´Ù.");
                formCheckMsg.color = Color.red;

            }
            else
            {
                checkPopupManager.Appear(playerName);
                formCheckMsg.color = Color.blue;
            }
        }
    }
}
