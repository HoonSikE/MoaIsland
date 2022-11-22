using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopupManager_Scene3 : MonoBehaviour
{
    // 메인 카메라
    public Camera MainCamera;

    // 사인 카메라
    public Camera SignCamera;

    public TalkManager_Scene3 talkeManager;

    public GameObject SignPanel;

    public GameObject signDoneButton;

    public GameObject sign3D;

    // 통장
    public GameObject account;
    public GameObject deposit;
    public GameObject interest;
    public GameObject withdrawal;

    public GameObject Letter;

    public GameObject QuestWindow;

    public void changeMainToSign()
    {
        MainCamera.enabled = false;
        SignPanel.SetActive(true);
        QuestWindow.SetActive(false);
        sign3D.SetActive(true);
        SignCamera.enabled = true;
        signDoneButton.SetActive(true);
    }

    public void changeSignToMain()
    {
        MainCamera.enabled = true;
        SignCamera.enabled = false;
    }

    public void ButtonClick()
    {
        SignPanel.SetActive(false);
        sign3D.SetActive(false);
        talkeManager.isPopupOpen = false;
        signDoneButton.SetActive(false);
        talkeManager.talkPanel.SetActive(true);
        QuestWindow.SetActive(true);
        changeSignToMain();
    }

    public void depositPopup()
    {
        account.SetActive(true);
        deposit.SetActive(true);
    }

    public void interestPopup()
    {
        account.SetActive(true);
        interest.SetActive(true);
    }

    public void withdrawalPopup()
    {
        account.SetActive(true);
        withdrawal.SetActive(true);
    }

    public void accountButtonClick()
    {
        account.SetActive(false);
        talkeManager.isPopupOpen = false;
        talkeManager.talkPanel.SetActive(true);
    }

    public void letterPopup()
    {
        Letter.SetActive(true);
    }

    public void letterButtonClick()
    {
        Letter.SetActive(false);
        talkeManager.isPopupOpen = false;
        talkeManager.talkPanel.SetActive(true);
    }
}
