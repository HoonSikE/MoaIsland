using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampStart2 : MonoBehaviour
{
    public StampScript stampstart2;
    public GameObject FM2;
    public GameObject GM2;
    public GameObject Stamp2;
    // Start is called before the first frame update
    private void Awake()
    {
        stampstart2 = FindObjectOfType<StampScript>();
        stampstart2.startStamp();
        Invoke("startTwo",3f);
    }

    // Update is called once per frame
    public void startTwo()
    {
        Stamp2.SetActive(false);
        FM2.SetActive(true);
        GM2.SetActive(true);
    }
}
