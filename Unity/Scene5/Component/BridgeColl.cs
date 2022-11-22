using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//특정구역에 충돌이 감지되면 f/o -> 다리넘어갈때 f/o 사용

public class BridgeColl : MonoBehaviour
{
    public BridgeFO fo;
    public GameObject onbridge;
    // Start is called before the first frame update
    void Start()
    {
        fo = FindObjectOfType<BridgeFO>();
        onbridge = GameObject.Find("Bridge");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        
        
        if (collision.collider.tag == "Bridge")
        {
            Debug.Log("1실행완료");
            
            if(fo == null)
            {
                Debug.Log("객체 null입니다");
                return;
            }
            fo.Fade();
        }
    }
        
    
}
