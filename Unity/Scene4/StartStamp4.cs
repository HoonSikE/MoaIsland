using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStamp4 : MonoBehaviour
{
    public StampScript stampstart4;
    public GameObject FM4;
    public GameObject GM4;
    public GameObject Stamp4;
    // Start is called before the first frame update
    private void Awake()
    {
        stampstart4 = FindObjectOfType<StampScript>();
        stampstart4.startStamp();
        Invoke("startFour", 3f);
    }

    // Update is called once per frame
    public void startFour()
    {
        Stamp4.SetActive(false);
        FM4.SetActive(true);
        GM4.SetActive(true);
    }
}
