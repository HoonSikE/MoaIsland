using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class TodayDate : MonoBehaviour
{

    [SerializeField] Text today;

    // Update is called once per frame
    void Update()
    {
        today.text = DateTime.Now.ToString("yyMMdd");
    }
}
