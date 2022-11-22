using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Woong : MonoBehaviour
{
    public AudioSource woongsung;
    // Start is called before the first frame update
    void Start()
    {
        woongsung = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void go()
    {
        woongsung.Play();
    }
    public void stop()
    {
        woongsung.Stop();
    }
}
