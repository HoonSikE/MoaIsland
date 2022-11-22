using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
 
// 시작화면 매니저
public class StartManager_Scene0 : MonoBehaviour {
    public GameObject FadeManager;
    public GameObject StartCanvas;
    public GameObject Scene0_1;
    public GameObject Player;
    public GameObject Manual;

    public void StartMoa(){
        FadeManager.SetActive(true);
        StartCanvas.SetActive(false);
        Scene0_1.SetActive(true);
        Player.SetActive(true);
    }

    public void OpenManual()
    {
        Debug.Log("hello");
        Manual.SetActive(true);
    }

}
