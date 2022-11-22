using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 대화 매니저
public class StampManager_Components : MonoBehaviour {
    public StampScript sc;

    void Awake()
    {
        sc = FindObjectOfType<StampScript>();
        sc.startStamp();
    }
}
