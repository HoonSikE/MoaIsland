using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Ư�������� �浹�� �����Ǹ� f/o -> �ٸ��Ѿ�� f/o ���

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
            Debug.Log("1����Ϸ�");
            
            if(fo == null)
            {
                Debug.Log("��ü null�Դϴ�");
                return;
            }
            fo.Fade();
        }
    }
        
    
}
