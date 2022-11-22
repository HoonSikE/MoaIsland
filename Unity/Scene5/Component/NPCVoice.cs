using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVoice : MonoBehaviour
{
    public AudioSource npcVoice;
    // Start is called before the first frame update
    void Start()
    {
        npcVoice = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void go()
    {
        npcVoice.loop = false;
        npcVoice.Play();
    }
}
