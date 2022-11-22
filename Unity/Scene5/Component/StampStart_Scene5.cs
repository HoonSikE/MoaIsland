using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대화 매니저
public class StampStart_Scene5 : MonoBehaviour {
    public GameObject Stamp;
    public GameObject FadeManager;
    public GameObject Map;
    public GameObject QuestManager;

    void Awake()
    {
        Invoke("Startscene", 3f);
    }
    public void Startscene()
    {
        Stamp.SetActive(false);
        FadeManager.SetActive(true);
        Map.SetActive(true);
        QuestManager.SetActive(true);
    }
}
