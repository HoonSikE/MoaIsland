using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StampStart3 : MonoBehaviour
{
    public StampScript stampstart3;
    public GameObject FM3;
    public GameObject GM3;
    public GameObject Stamp3;
    // Start is called before the first frame update
    private void Awake()
    {
        stampstart3 = FindObjectOfType<StampScript>();
        stampstart3.startStamp();
        Invoke("startThree", 3f);
    }

    // Update is called once per frame
    public void startThree()
    {
        Stamp3.SetActive(false);
        FM3.SetActive(true);
        GM3.SetActive(true);
    }
}
