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
        playerNameInputField.characterLimit = 5; // InputField ���� �� ����
        //playerNameInputField.onValueChanged.AddListener( // InputField �Է� �� ����, �ѱ�, ���ڸ� ����
        //    (word) => playerNameInputField.text = Regex.Replace(word, @"[^0-9a-zA-Z��-�R]", "")
        //);

    }
    public void Submit()
    {
        playerName = playerNameInputField.text.Trim();
        if (playerName.Length != 0)
        {
            bool flag = Regex.IsMatch(playerName, @"^[��-�R]*$");
            
            if (!flag)
            {
                Debug.Log("�߸��� �Է� �����Դϴ�.");
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
