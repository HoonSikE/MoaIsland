using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//bridge�� ��������, efftitleopening-> �������� ȿ�� : �����ϰ� ���⶧ f/o ���� bridge set true

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
                Debug.Log("���̴�!");
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
                Debug.Log("��ü null�Դϴ�");
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
