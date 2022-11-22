using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bridge가 지어진다, efftitleopening-> 지어지는 효과 : 실행하고 멈출때 f/o 이후 bridge set true

public class MakeBridge : MonoBehaviour
{
    public BridgeFO fo;
    public GameObject bridge;
    public ParticleSystem Eff_Title_Opening;
    // Start is called before the first frame update
    void Start()
    {
        bridge.SetActive(false);
        Eff_Title_Opening.Pause();
        fo = FindObjectOfType<BridgeFO>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            if (Eff_Title_Opening == null)
            {
                Debug.Log("널이다!");
                return;
            }
            if (!Eff_Title_Opening.isPlaying)
            {
                Eff_Title_Opening.Play();
            }
            
            
            
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            
            if (fo == null)
            {
                Debug.Log("객체 null입니다");
                return;
            }
            fo.Fade();
            Invoke("build",1f);
        }
    }
    void build()
    {
        if (Eff_Title_Opening == null)
        {
            return;
        }
        Eff_Title_Opening.Stop(true, ParticleSystemStopBehavior.StopEmittingAndClear);
        bridge.SetActive(true);
    }
}
