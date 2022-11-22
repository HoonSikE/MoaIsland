using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartStamp6 : MonoBehaviour
{
    // Start is called before the first frame update
    public StampScript stampstart6;
    public GameObject FM6;
    public GameObject GM6;
    public GameObject map6;
    public GameObject Stamp6;
    // Start is called before the first frame update
    private void Awake()
    {
        stampstart6 = FindObjectOfType<StampScript>();
        stampstart6.startStamp();
        Invoke("startsix", 3f);
    }

    // Update is called once per frame
    public void startsix()
    {
        Stamp6.SetActive(false);
        FM6.SetActive(true);
        GM6.SetActive(true);
        map6.SetActive(true);
    }
}
